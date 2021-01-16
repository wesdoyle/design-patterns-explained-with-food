using System;
using CreationalPatterns.AbstractFactory.MealPlans.Keto;

namespace CreationalPatterns.AbstractFactory.MealPlanFactories {
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
