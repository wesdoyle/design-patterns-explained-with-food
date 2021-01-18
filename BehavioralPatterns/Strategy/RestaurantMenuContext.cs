using Newtonsoft.Json;
using RealisticDependencies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BehavioralPatterns.Strategy {
    public class RestaurantMenuContext {
        /// <summary>
        /// This Context works with an object instance that implements IStrategy. 
        /// It never works with directly with an implementation of IStrategy.
        /// </summary>
        private IMenuGenerationStrategy _strategy;

        private readonly IApplicationLogger _logger;
        private readonly IDateTimeProvider _date;
        private readonly IDatabase _menuDatabase;

        public RestaurantMenuContext() { }

        public RestaurantMenuContext(
            IMenuGenerationStrategy strategy, 
            IApplicationLogger logger, 
            IDatabase db,
            IDateTimeProvider date) {
            _strategy = strategy;
            _logger = logger;
            _menuDatabase = db;
            _date = date;

            // Seed the database with all possible menu items we can provide
            InitializeDatabase().Wait();
        }

        public void SetStrategy(IMenuGenerationStrategy strategy) {
            _strategy = strategy;
        }

        // The Context delegates some work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public async Task PublishMenu() {
            _logger.LogInfo("Generating the Menu.");

            var currentMenu = await _strategy.GenerateMenu();

            foreach (var item in currentMenu.MenuItems) {
                _logger.LogInfo(
                    $"- {item.Name} | {item.Description} | {item.Price}", ConsoleColor.Cyan);
            }
        }

        private async Task InitializeDatabase() {
            await _menuDatabase.Connect();
            var allMenuItems = GetAllMenuItems();
            var listOfInserts = new List<Task>();
            foreach (var item in allMenuItems) {
                var jsonItem = SerializeMenuItemAsJson(item);
                var task = _menuDatabase.WriteData(item.Name, jsonItem);
                listOfInserts.Add(task);
            }
            await Task.WhenAll(listOfInserts);
        }

        private static List<MenuItem> GetAllMenuItems() => new() {
            new("scrambled eggs", "2 scrambled eggs with coffee", 1.20m),
            new("french toast", "3 pieces of french toast with maple syrup", 3.25m),
            new("bagel with lox", "wheat bagel with cream cheese and lox", 2.10m),
            new("black bean burrito", "black beans, lettuce, cheese", 3.80m),
            new("chips and salsa", "corn chips and fresh salsa", 2.40m),
            new("curry rice", "peanut curry sauce with white rice", 3.20m),
            new("wild rice soup", "wild rice with carrots, celery, peppers", 5.20m),
        };

        private static string SerializeMenuItemAsJson(MenuItem menuItem) 
            => JsonConvert.SerializeObject(menuItem);
    }
}
