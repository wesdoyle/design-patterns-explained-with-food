using System;
using System.Collections.Generic;

namespace CreationalPatterns.AbstractFactory.MealPlans.Keto {
    public class KetoDessertMenu : IMenu {
        public List<string> MakeShoppingList()
            => new List<string> { "peanut butter", "dark chocolate", "ricotta" };

        public void PrintDescription() 
            => Console.WriteLine("The Keto dessert menu features high-fat, sugar-free " +
                "chocolate bars and high-fat low carb cheesecake");

        public void PrintMenu() 
            => Console.WriteLine("Peanut butter chocolate bars, sugar-free cheesecake");
    }
}
