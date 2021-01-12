using CreationalPatterns.AbstractFactory.Menus;
using System;

namespace CreationalPatterns.AbstractFactory.MenuFactories {
    public class KetoMealPlanFactory : IMealPlanFactory {
        public IMenu GenerateDessertsMenu() {
            Console.WriteLine("== 🍨 Generating a Keto Dessert Menu... ==");
            return new KetoDessertMenu();
        }

        public IMenu GenerateLunchesMenu() {
            Console.WriteLine("== 🧈 Generating a Keto Lunch Menu... ==");
            return new KetoLunchMenu();
        }
    }
}
