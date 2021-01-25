using CreationalPatterns.AbstractFactory.MealPlans.Keto;
using RealisticDependencies;

namespace CreationalPatterns.AbstractFactory.MealPlanFactories {
    public class KetoMealPlanFactory : IMealPlanFactory {
        private readonly IApplicationLogger _logger;

        public KetoMealPlanFactory(IApplicationLogger logger) {
            _logger = logger;
        }
        
        public IMenu GenerateDessertsMenu() {
            _logger.LogInfo("== 🍨 Generating a Keto Dessert Menu... ==");
            return new KetoDessertMenu();
        }

        public IMenu GenerateLunchesMenu() {
            _logger.LogInfo("== 🧈 Generating a Keto Lunch Menu... ==");
            return new KetoLunchMenu();
        }
        
        public IShoppingList GenerateShoppingList() {
            _logger.LogInfo("== 🧈 Generating a Keto Shopping List... ==");
            return new KetoShoppingList();
        }
    }
}
