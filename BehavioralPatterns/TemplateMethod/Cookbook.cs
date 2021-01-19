using System;
using System.Collections.Generic;
using RealisticDependencies;

namespace BehavioralPatterns.TemplateMethod {
    public class Cookbook {
        private readonly IApplicationLogger _logger;
        private readonly List<CookbookRecipe> _recipes;
        
        public Cookbook(IApplicationLogger logger, List<CookbookRecipe> recipes) {
            _logger = logger;
            _recipes = recipes;
        }

        public void Print() {
            foreach (var recipe in _recipes) {
                recipe.PrintSteps();
                _logger.LogInfo("-------------------------------", ConsoleColor.DarkMagenta);
            }
        }
    }
}
