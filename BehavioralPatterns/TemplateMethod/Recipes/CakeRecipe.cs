using System;

namespace BehavioralPatterns.TemplateMethod.Recipes {
    public class CakeRecipe : CookbookRecipe {
        protected override void PrintTitle() {
            Console.WriteLine("~ Vanilla Cake ~");
        }

        protected override void PrintRequiredEquipment() {
            Console.WriteLine("- Measuring Cup");
            Console.WriteLine("- Mixing Bowl");
            Console.WriteLine("- 9 X 9-inch Cake Pan");
        }

        protected override void PrintRequiredIngredients() {
            Console.WriteLine("- 1 cup sugar");
            Console.WriteLine("- 1/2 cup butter");
            Console.WriteLine("- 2 eggs");
            Console.WriteLine("- 2 teaspoons vanilla extract");
            Console.WriteLine("- 1-1/2 cups flour");
            Console.WriteLine("- 1-3/4 tsp baking powder");
            Console.WriteLine("- 1/2 cup milk");
        }

        protected override void PrintCookingSteps() {
            Console.WriteLine("- Preheat Oven to 350 degrees F");
            Console.WriteLine("- Grease and Flour a 9 x 9-inch Pan");
            Console.WriteLine("- Mix sugar and butter");
            Console.WriteLine("- Beat in the eggs");
            Console.WriteLine("- Stir in the vanilla");
            Console.WriteLine("- Combine flour and baking powder and add to mixture");
            Console.WriteLine("- Stir in the milk");
            Console.WriteLine("- Pour onto the Cake Pan");
            Console.WriteLine("- Bake for 30-40 minutes in preheated Oven");
        }
    }
}
