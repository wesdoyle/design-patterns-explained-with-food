using System.Collections.Generic;
using BehavioralPatterns.TemplateMethod;
using BehavioralPatterns.TemplateMethod.Recipes;
using RealisticDependencies;

namespace CookbookPrinter {
    internal class Program {
        /// <summary>
        /// We run a cookbook printing business, where amateur chefs send in their favorite home-made
        /// recipes to be printed in self-published family cookbooks.
        /// Many of the steps in our printing press operations for cookbooks are the same,
        /// except for the details of the concrete recipes send in by our clients.  We can leverage a template
        /// method to provide optional virtual hooks and required abstract methods in a base class
        /// that defines our printing algorithm to print specific recipes for the book.
        /// </summary>
        private static void Main() {
            var logger = new ConsoleLogger();
            logger.LogInfo("📘 Welcome to the Cookbook Printer");

            var clientRecipes = new List<CookbookRecipe> {
                new CakeRecipe(logger), 
                new CurryRecipe(logger)
            };

            var cookbook = new Cookbook(logger, clientRecipes);

            cookbook.Print();
        }
    }
}
