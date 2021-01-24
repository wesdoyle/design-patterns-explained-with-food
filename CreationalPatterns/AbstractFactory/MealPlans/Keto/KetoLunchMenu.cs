using System;

namespace CreationalPatterns.AbstractFactory.MealPlans.Keto {
    public class KetoLunchMenu : IMenu {
        public void PrintDescription() 
            => Console.WriteLine("The Keto menu features a diet high in fat, " +
                "moderately high in protein, and very low in carbohydrates.");

        public void PrintMenu() 
            => Console.WriteLine("Scrambled Eggs, Creamed Spinach, Guacamole");
    }
}
