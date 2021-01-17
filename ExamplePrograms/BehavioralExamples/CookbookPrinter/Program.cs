using System;
using System.Collections.Generic;
using BehavioralPatterns.TemplateMethod;
using BehavioralPatterns.TemplateMethod.Recipes;

namespace CookbookPrinter {
    internal class Program {
        /// <summary>
        /// We run a cookbook-printing business, where amateur chefs send in their favorite home-made
        /// recipes to be printed in self-published family cookbooks.
        /// Many of the steps in our printing press operations for cookbooks are the same,
        /// except for the details of the concrete recipes send in by our clients.  We can leverage a template
        /// method to provide optional virtual hooks and required abstract methods in a base class
        /// that defines our printing algorithm to print specific recipes for the book.
        /// </summary>
        private static void Main() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("📘 Welcome to the Cookbook Printer");
            Console.WriteLine("-----------------------------------");

            var clientRecipes = new List<CookbookRecipe> {
                new CakeRecipe(), 
                new CurryRecipe()
            };

            var cookbook = new Cookbook(clientRecipes);

            cookbook.Print();
        }
    }
}
