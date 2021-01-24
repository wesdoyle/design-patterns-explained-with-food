using RealisticDependencies;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BehavioralPatterns.Strategy.Strategies {
    /// <summary>
    /// Here we have a menu-building strategy that accounts for
    /// Menu item price - we return a menu items containing only
    /// items over a specified PriceThreshold
    /// </summary>
    public class PriceRangeMenuStrategy : IMenuGenerationStrategy {
        private readonly IDatabase _menuDatabase;
        private const decimal PriceThreshold = 3m;

        public PriceRangeMenuStrategy(IDatabase menuDatabase) {
            _menuDatabase = menuDatabase;
        }

        /// <summary>
        /// The method required by the interface to implement this strategy
        /// </summary>
        /// <returns></returns>
        public async Task<Menu> GenerateMenu() {
            var allMenuItems = await _menuDatabase.DumpData();
            var allItemsDeserialized = allMenuItems
                .Select(item => JsonConvert.DeserializeObject<MenuItem>(item));
            var filteredItems = new List<MenuItem>(allItemsDeserialized)
                .Where(item => item.Price > PriceThreshold)
                .ToList();
            return new Menu(filteredItems);
        }
    }
}
