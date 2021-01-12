using System;
using System.Collections.Generic;

namespace CreationalPatterns.AbstractFactory.Menus {
    public class KetoLunchMenu : IMenu {
        public List<string> GetMenuIngredients() 
            => new List<string> { "eggs", "butter", "cheese", "avocado", "onion", "spinach" }

        public void PrintDescription() 
            => Console.WriteLine("The Keto menu features a diet high in fat, " +
                "moderately high in protein, and very low in carbohydrates.");

        public void PrintMenu() 
            => Console.WriteLine("Scrambled Eggs, Creamed Spinach, Guacamole");
    }
}
