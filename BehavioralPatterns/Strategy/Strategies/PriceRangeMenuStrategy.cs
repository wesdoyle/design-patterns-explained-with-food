using RealisticDependencies;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BehavioralPatterns.Strategy.Strategies {
    public class PriceRangeMenuStrategy : IMenuGenerationStrategy {
        private readonly IDatabase _menuDatabase;

        public PriceRangeMenuStrategy(IDatabase menuDatabase) {
            _menuDatabase = menuDatabase;
        }

        public async Task<Menu> GenerateMenu() {
            var allMenuItems = await _menuDatabase.DumpData();
            var allIteAmsDeserialized = allMenuItems.Select(item => JsonConvert.DeserializeObject<MenuItem>(item));
            var filteredItems = new List<MenuItem>();
            return new Menu(filteredItems);
        }
    }
}
