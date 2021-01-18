using Newtonsoft.Json;
using RealisticDependencies;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BehavioralPatterns.Strategy {
    public class RestaurantMenuContext : IAsyncDisposable {
        /// <summary>
        /// This Context works with an object instance that implements IStrategy. 
        /// It always works with the interface.
        /// </summary>
        private IMenuGenerationStrategy _strategy;

        private readonly IApplicationLogger _logger;
        private readonly IDatabase _menuDatabase;

        /// <summary>
        /// This constructor variation presets the context with a strategy.
        /// We can also mutate the Strategy at runtime by exposing setter method.
        /// </summary>
        /// <param name="strategy"></param>
        /// <param name="logger"></param>
        /// <param name="menuDatabase"></param>
        public RestaurantMenuContext(
            IMenuGenerationStrategy strategy, 
            IApplicationLogger logger, 
            IDatabase menuDatabase) {
            _strategy = strategy;
            _logger = logger;
            _menuDatabase = menuDatabase;

            // Connect and Seed the database with all possible menu items we can provide
            // We close the connection when we dispose of this Context.
            InitializeDatabase().Wait();
        }
        
        /// <summary>
        /// This constructor variation does not set a default strategy.
        /// In this case, we must set the Strategy at runtime by exposing setter method.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="menuDatabase"></param>
        public RestaurantMenuContext(
            IApplicationLogger logger, 
            IDatabase menuDatabase) {
            _logger = logger;
            _menuDatabase = menuDatabase;
            
            // Connect and Seed the database with all possible menu items we can provide
            // We close the connection when we dispose of this Context.
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
            // Open a connection to the database. We close it when we dispose of this Context
            await _menuDatabase.Connect();
            var semaphore = new SemaphoreSlim(1);
            await semaphore.WaitAsync(); 

            _logger.LogInfo("Seeding full menu into the database", ConsoleColor.Green);
            var allMenuItems = GetAllMenuItems();
            var listOfInserts = new List<Task>();

            try {
                foreach (var item in allMenuItems) {
                    var jsonItem = SerializeMenuItemAsJson(item);
                    var task = _menuDatabase.WriteData(item.Name, jsonItem);
                    listOfInserts.Add(task);
                }

                await Task.WhenAll(listOfInserts);
            } finally {
                semaphore.Release();
            }
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

        public async ValueTask DisposeAsync() {
            await _menuDatabase.Disconnect();
        }
    }
}
