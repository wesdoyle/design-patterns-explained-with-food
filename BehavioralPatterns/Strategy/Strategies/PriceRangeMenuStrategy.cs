using RealisticDependencies;
using System.Collections.Generic;

namespace BehavioralPatterns.Strategy.Strategies {
    public class PriceRangeMenuStrategy : IMenuGenerationStrategy {
        public PriceRangeMenuStrategy(IDatabase db) { }
        public Menu GenerateMenu() {
            var filteredItems = new List<MenuItem>();
            return new Menu(filteredItems);
        }
    }
}
