using System;
using CreationalPatterns.AbstractFactory.MealPlans.Vegetarian;
using RealisticDependencies;

namespace CreationalPatterns.AbstractFactory.MealPlanFactories {
    public class VegetarianMealPlanFactory : IMealPlanFactory {
        private readonly IApplicationLogger _logger;

        public VegetarianMealPlanFactory(IApplicationLogger logger) {
            _logger = logger;
        }
        public IMenu GenerateDessertsMenu() {
            _logger.LogInfo("== 🥭 Generating a Vegetarian Dessert Menu... ==", ConsoleColor.Green);
            return new VegetarianDessertMenu();
        }

        public IMenu GenerateLunchesMenu() {
            _logger.LogInfo("== 🥕 Generating a Vegetarian Lunch Menu... ==", ConsoleColor.Green);
            return new VegetarianLunchMenu();
        }
        
        public IShoppingList GenerateShoppingList() {
            _logger.LogInfo("== 🥕 Generating a Vegetarian Shopping List... ==", ConsoleColor.Green);
            return new VegetarianShoppingList();
        }
    }
}
