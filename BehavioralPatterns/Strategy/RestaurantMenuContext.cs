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

            InitializeDatabase();
        }

        private async Task InitializeDatabase() {
            await _menuDatabase.Connect();
            var allMenuItems = GetAllMenuItems();
            var listOfInserts = new List<Task>();
            foreach (var item in allMenuItems) {
                var task = _menuDatabase.WriteData(item);
                listOfInserts.Add(task);
            }
            await Task.WhenAll(listOfInserts);
        }

        private List<MenuItem> GetAllMenuItems() {
            return new(new MenuItem);
        }

        private static void SerializeMenuItemAsJson(MenuItem menuItem) 
            => JsonConvert.SerializeObject(menuItem);

        public void SetStrategy(IMenuGenerationStrategy strategy) {
            _strategy = strategy;
        }

        // The Context delegates some work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public void PublishMenu() {
            _logger.LogInfo("Generating the Menu.");

            var currentMenu = _strategy.GenerateMenu(_date.CurrentUtc());

            foreach (var item in currentMenu.MenuItems) {
                _logger.LogInfo(
                    $"- {item.Name} | {item.Description} | {item.Price}}",
                    System.ConsoleColor.Cyan);
            }
        }
    }
}
