using System.Collections.Generic;

namespace CreationalPatterns.AbstractFactory.MealPlans.Keto {
    public class KetoShoppingList: IShoppingList {
        public List<string> MakeShoppingList()
            => new() { "butter", "meat", "kale", "peanut butter", "dark chocolate", "ricotta" };
    }
}
