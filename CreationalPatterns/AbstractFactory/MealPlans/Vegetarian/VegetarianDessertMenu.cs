using System;

namespace CreationalPatterns.AbstractFactory.MealPlans.Vegetarian {
    public class VegetarianDessertMenu : IMenu {
        public void PrintDescription() 
            => Console.WriteLine("The Vegetarian dessert menu features plant-based " +
                "baked goods and fresh fruit");

        public void PrintMenu() 
            => Console.WriteLine("Brownie, Orange Shebert, Blackberry Crisp");
    }
}
