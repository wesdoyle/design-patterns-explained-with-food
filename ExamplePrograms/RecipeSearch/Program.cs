using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealisticDependencies;
using StructuralPatterns.Adapter;

namespace RecipeSearch {
    internal class Program {
        /// <summary>
        /// Here we use the Adapter Pattern to adapt the XML result we receive from the RecipesApi
        /// to work with our client-side code, which "only works" with JSON.  Here we gain the benefit
        /// of allowing the API dependency to just continue working as it needs to while changing the
        /// interface of our Adapter to match what's needed here in the client.
        ///
        /// If the interface of the RecipesApi changes, or if its return types or structure get updated,
        /// Our client code here will likely remain unchanged, as we can then write a new Adapter or update
        /// our existing Adapter code.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("👩‍🍳  Aggregating Recipes...");

            // The RecipesAPI Produces XML results
            var recipesApi = new RecipesApi();

            // Let's adapt it with our RecipeFinder adapter to produce JSON instead
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

            // We only want to work with JSON in this client
            PrintJsonRecipes(tasks);
        }

        private static void PrintJsonRecipes(IEnumerable<Task<string>> recipes) {
            foreach (var recipe in recipes) {
                Console.WriteLine(recipe.Result);
            }
        }
    }
}
