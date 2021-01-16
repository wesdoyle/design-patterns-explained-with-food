using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using RealisticDependencies;

namespace StructuralPatterns.Adapter {
    public class RecipeFinder : IAdaptsRecipesToJson {
        private readonly RecipesApi _recipesApi;

        public RecipeFinder(RecipesApi recipesApi) {
            _recipesApi = recipesApi;
        }

        public async Task<string> GetRecipeAsJson(string recipeName) {
            var recipeXml = await _recipesApi.MakeHttpRequestForRecipe(recipeName);
            var doc = new XmlDocument();
            doc.LoadXml(recipeXml);
            var jsonResult = JsonConvert.SerializeXmlNode(doc);
            return jsonResult;
        }
    }
}