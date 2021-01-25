using System;

namespace CreationalPatterns.AbstractFactory.MealPlans.Keto {
    public class KetoDessertMenu : IMenu {
        public void PrintDescription() 
            => Console.WriteLine("The Keto dessert menu features high-fat, sugar-free " +
                "chocolate bars and high-fat low carb cheesecake");

        public void PrintMenu() 
            => Console.WriteLine("Peanut butter chocolate bars, sugar-free cheesecake");
    }
}
