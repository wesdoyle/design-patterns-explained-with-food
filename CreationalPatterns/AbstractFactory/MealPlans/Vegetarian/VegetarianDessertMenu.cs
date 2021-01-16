using System;
using System.Collections.Generic;

namespace CreationalPatterns.AbstractFactory.MealPlans.Vegetarian {
    public class VegetarianDessertMenu : IMenu {
        public List<string> MakeShoppingList()
            => new List<string> { "oranges", "dark chocolate", "blackberries" };

        public void PrintDescription() 
            => Console.WriteLine("The Vegetarian dessert menu features plant-based " +
                "baked goods and fresh fruit");

        public void PrintMenu() 
            => Console.WriteLine("Brownie, Orange Shebert, Blackberry Crisp");
    }
}
