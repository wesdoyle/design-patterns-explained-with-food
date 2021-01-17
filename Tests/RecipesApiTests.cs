using FluentAssertions;
using Moq;
using RealisticDependencies;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit;

namespace Tests {
    public class RecipesApiTests {
        private XmlSerializer xml = new XmlSerializer(typeof(Recipe));

        [Fact]
        public async Task MakeHttpRequestForRecipe_Gets_Value_From_Database_Given_Recipe() {
            var logger = new Mock<IApplicationLogger>();
            var api = new RecipesApi(logger.Object);
            var result = await api.MakeHttpRequestForRecipe("mashed_potatoes");
            using var reader = new StringReader(result);
            var recipe = (Recipe) xml.Deserialize(reader);
            recipe.Should().NotBeNull();
            recipe.Name.Should().Be("Mashed Potatoes");
        }

        [Fact]
        public async Task MakeHttpRequestForRecipe_Logs_Recipe() {
            var logger = new Mock<IApplicationLogger>();
            var api = new RecipesApi(logger.Object);
            var result = await api.MakeHttpRequestForRecipe("mashed_potatoes");
            logger.Verify(mock
                => mock.LogInfo(
                    It.IsAny<string>(),
                    It.IsAny<ConsoleColor>()), 
                Times.AtLeastOnce());
        }
    }
}
