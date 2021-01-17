using System;

namespace BehavioralPatterns.TemplateMethod {
    public abstract class CookbookRecipe {

        // The template method defines the skeleton of an algorithm.
        // Steps are either implemented in the base class (here),
        // Forcibly overridden in derived classes via inheritance (abstract),
        // Or optionally overridden via inheritance (virtual)
        public void PrintSteps() {
            // Required Overridden - Book title goes at the top of every recipe
            PrintTitle();

            // Base implementation - Equipment heading goes at the top of every recipe
            PrintEquipmentHeading();

            // Required Overridden 
            PrintRequiredEquipment();

            // Base implementation
            PrintIngredientsHeading();

            // Required Overridden 
            PrintRequiredIngredients();

            // Optional Overridden (Hook) 
            PrintPossibleSubstitutions();

            // Base implementation
            PrintStepsHeading();

            // Required Overridden 
            PrintCookingSteps();

            // Optional Overridden (Hook) 
            PrintOptionalServingSuggestions();
        }

        protected void PrintEquipmentHeading() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("~ Required Equipment ~");
            Console.ResetColor();
        }

        protected void PrintIngredientsHeading() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("~ Ingredients List ~");
            Console.ResetColor();
        }

        protected void PrintStepsHeading() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("~ Cooking Steps ~");
            Console.ResetColor();
        }


        // These operations have to be implemented in CookbookRecipe subclasses.
        protected abstract void PrintTitle();

        protected abstract void PrintRequiredEquipment();

        protected abstract void PrintRequiredIngredients();

        protected abstract void PrintCookingSteps();

        // Hooks can be optionally overridden by subclasses.  By default, they are empty.
        protected virtual void PrintPossibleSubstitutions() { }

        protected virtual void PrintOptionalServingSuggestions() { }
    }
}
