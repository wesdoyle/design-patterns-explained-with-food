using System;

namespace BehavioralPatterns.TemplateMethod.Recipes {
    public class CurryRecipe : CookbookRecipe {
        protected override void PrintTitle() {
            Console.WriteLine("~ Thai Curry ~");
        }

        protected override void PrintRequiredEquipment() {
            Console.WriteLine("- Measuring Cup");
            Console.WriteLine("- Mixing Bowl");
            Console.WriteLine("- Cast-Iron Skillet");
        }

        protected override void PrintRequiredIngredients() {
            Console.WriteLine("- 1-1/2 cup brown jasmine rice");
            Console.WriteLine("- 1 tbsp coconut oil");
            Console.WriteLine("- 1 chopped white onion");
            Console.WriteLine("- 2 cloves garlic");
            Console.WriteLine("- 2 green or red peppers");
            Console.WriteLine("- 1 cup chopped carrots");
            Console.WriteLine("- 2 tbsp red curry paste");
            Console.WriteLine("- 1 can coconut milk");
            Console.WriteLine("- 1/2 can water");
            Console.WriteLine("- few drops of soy sauce");
            Console.WriteLine("- juice from a small lime");
            Console.WriteLine("- 1 tbsp chopped ginger");
        }

        protected override void PrintPossibleSubstitutions() {
            Console.WriteLine("- white rice");
            Console.WriteLine("- olive oil");
            Console.WriteLine("- green curry paste");
        }

        protected override void PrintCookingSteps() {
            Console.WriteLine("- cook the rice");
            Console.WriteLine("- cook the carrot, onions, and peppers in coconut oil for ~5 minutes");
            Console.WriteLine("- add garlic and ginger and cook for a minute");
            Console.WriteLine("- add the curry paste");
            Console.WriteLine("- add the coconut milk and water");
            Console.WriteLine("- add the soy sauce and lime juice");
        }

        protected override void PrintOptionalServingSuggestions() {
            Console.WriteLine("- serve over rice");
            Console.WriteLine("- serve with a side of chili paste");
        }

    }
}
