using CreationalPatterns.AbstractFactory.Menus;
using System;

namespace CreationalPatterns.AbstractFactory.MenuFactories {
    public class VegetarianMealPlanFactory : IMealPlanFactory {
        public IMenu GenerateDessertsMenu() {
            Console.WriteLine("== 🥭 Generating a Vegetarian Dessert Menu... ==");
            return new VegetarianDessertMenu();
        }

        public IMenu GenerateLunchesMenu() {
            Console.WriteLine("== 🥕 Generating a Vegetarian Lunch Menu... ==");
            return new VegetarianLunchMenu();
        }
    }
}
