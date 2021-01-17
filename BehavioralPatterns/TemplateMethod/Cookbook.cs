using System;
using System.Collections.Generic;

namespace BehavioralPatterns.TemplateMethod {
    public class Cookbook {
        private readonly List<CookbookRecipe> _recipes;
        public Cookbook(List<CookbookRecipe> recipes) {
            _recipes = recipes;
        }

        public void Print() {
            foreach (var recipe in _recipes) {
                recipe.PrintSteps();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("-------------------------------");
                Console.ResetColor();
            }
        }
    }
}
