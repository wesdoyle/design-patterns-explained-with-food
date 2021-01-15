using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealisticDependencies;
using StructuralPatterns.Adapter;

namespace RecipeSearch {
    class Program {
        static async Task Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("👩‍🍳  Aggregating Recipes...");

            var recipesApi = new RecipesApi();
            var recipeFinder = new RecipeFinder(recipesApi);

            var mashedPotatoesResult = recipeFinder.GetRecipeAsJson("mashed_potatoes");
            var greenBeansResult = recipeFinder.GetRecipeAsJson("green_beans");
            var redCurryResult = recipeFinder.GetRecipeAsJson("red_curry");

            var tasks = new List<Task<string>> {
                mashedPotatoesResult,
                greenBeansResult,
                redCurryResult
            };

            await Task.WhenAll(tasks);

            foreach (var task in tasks) {
                Console.WriteLine(task.Result);
            }
        }
    }
}
