using System;
using System.Collections.Generic;

namespace CreationalPatterns.AbstractFactory.Menus {
    public class VegetarianLunchMenu : IMenu {
        public List<string> GetMenuIngredients()
            => new List<string> { "black beans, spices, kale, cucumber" };

        public void PrintDescription() 
            => Console.WriteLine("The Vegetarian menu features plant-based options without meat products");

        public void PrintMenu() 
            => Console.WriteLine("Black Bean Soup, Green Curry, Salad");
    }
}
