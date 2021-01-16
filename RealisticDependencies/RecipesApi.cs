using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RealisticDependencies {
    /// <summary>
    /// Mock Api that returns Recipes in XML format
    /// </summary>
    public class RecipesApi {
        private readonly Dictionary<string, Recipe> _database;
        
        public RecipesApi() {
            _database = GenerateDatabase();
        }

        /// <summary>
        /// Returns XML Response of a Recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public async Task<string> MakeHttpRequestForRecipe(string recipe) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Making HTTP request returning XML for: {recipe}");
            Console.ResetColor();

            await Task.Delay(2000);
            var databaseResponse = _database[recipe];
            
            var xmlSerializer = new XmlSerializer(databaseResponse.GetType());

            await using var stringWriter = new StringWriter();
            await using var writer = XmlWriter.Create(stringWriter, new XmlWriterSettings {Async = true});
            
            xmlSerializer.Serialize(writer, databaseResponse);
            var xml = stringWriter.ToString();
            return xml;
        }
        
        private static Dictionary<string, Recipe> GenerateDatabase() {
            return new() {
                { "mashed_potatoes", new Recipe("Mashed Potatoes", 30) },
                { "green_beans", new Recipe("Steamed Green Beans", 10) },
                { "red_curry", new Recipe("Red Curry", 60) },
            };
        }
    }
        
    public struct Recipe {
        public Recipe(string name, int prepTimeMinutes) {
            Name = name;
            PrepTimeMinutes = prepTimeMinutes;
        }
        
        public string Name { get; set; }
        public int PrepTimeMinutes { get; set; }
    }
}