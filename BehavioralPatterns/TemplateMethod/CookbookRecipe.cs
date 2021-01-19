using System;
using RealisticDependencies;

namespace BehavioralPatterns.TemplateMethod {
    public abstract class CookbookRecipe {
        protected readonly IApplicationLogger _logger;

        public CookbookRecipe(IApplicationLogger logger) {
            _logger = logger;
        }

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

        private void PrintEquipmentHeading() {
            Console.ForegroundColor = ConsoleColor.Blue;
            _logger.LogInfo("~ Required Equipment ~");
            Console.ResetColor();
        }

        private void PrintIngredientsHeading() {
            Console.ForegroundColor = ConsoleColor.Blue;
            _logger.LogInfo("~ Ingredients List ~");
            Console.ResetColor();
        }

        private void PrintStepsHeading() {
            Console.ForegroundColor = ConsoleColor.Blue;
            _logger.LogInfo("~ Cooking Steps ~");
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
