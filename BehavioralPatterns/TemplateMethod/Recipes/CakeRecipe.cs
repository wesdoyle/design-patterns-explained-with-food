using RealisticDependencies;

namespace BehavioralPatterns.TemplateMethod.Recipes {
    public class CakeRecipe : CookbookRecipe {

        public CakeRecipe(IApplicationLogger logger) : base(logger) { }
        
        protected override void PrintTitle() {
            _logger.LogInfo("~ Vanilla Cake ~");
        }

        protected override void PrintRequiredEquipment() {
            _logger.LogInfo("- Measuring Cup");
            _logger.LogInfo("- Mixing Bowl");
            _logger.LogInfo("- 9 X 9-inch Cake Pan");
        }

        protected override void PrintRequiredIngredients() {
            _logger.LogInfo("- 1 cup sugar");
            _logger.LogInfo("- 1/2 cup butter");
            _logger.LogInfo("- 2 eggs");
            _logger.LogInfo("- 2 teaspoons vanilla extract");
            _logger.LogInfo("- 1-1/2 cups flour");
            _logger.LogInfo("- 1-3/4 tsp baking powder");
            _logger.LogInfo("- 1/2 cup milk");
        }

        protected override void PrintCookingSteps() {
            _logger.LogInfo("- Preheat Oven to 350 degrees F");
            _logger.LogInfo("- Grease and Flour a 9 x 9-inch Pan");
            _logger.LogInfo("- Mix sugar and butter");
            _logger.LogInfo("- Beat in the eggs");
            _logger.LogInfo("- Stir in the vanilla");
            _logger.LogInfo("- Combine flour and baking powder and add to mixture");
            _logger.LogInfo("- Stir in the milk");
            _logger.LogInfo("- Pour onto the Cake Pan");
            _logger.LogInfo("- Bake for 30-40 minutes in preheated Oven");
        }
    }
}
