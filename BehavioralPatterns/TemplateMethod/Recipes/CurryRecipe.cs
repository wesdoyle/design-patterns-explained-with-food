using RealisticDependencies;

namespace BehavioralPatterns.TemplateMethod.Recipes {
    public class CurryRecipe : CookbookRecipe {

        public CurryRecipe(IApplicationLogger logger) : base(logger) { }
        
        protected override void PrintTitle() {
            _logger.LogInfo("~ Thai Curry ~");
        }

        protected override void PrintRequiredEquipment() {
            _logger.LogInfo("- Measuring Cup");
            _logger.LogInfo("- Mixing Bowl");
            _logger.LogInfo("- Cast-Iron Skillet");
        }

        protected override void PrintRequiredIngredients() {
            _logger.LogInfo("- 1-1/2 cup brown jasmine rice");
            _logger.LogInfo("- 1 tbsp coconut oil");
            _logger.LogInfo("- 1 chopped white onion");
            _logger.LogInfo("- 2 cloves garlic");
            _logger.LogInfo("- 2 green or red peppers");
            _logger.LogInfo("- 1 cup chopped carrots");
            _logger.LogInfo("- 2 tbsp red curry paste");
            _logger.LogInfo("- 1 can coconut milk");
            _logger.LogInfo("- 1/2 can water");
            _logger.LogInfo("- few drops of soy sauce");
            _logger.LogInfo("- juice from a small lime");
            _logger.LogInfo("- 1 tbsp chopped ginger");
        }

        protected override void PrintPossibleSubstitutions() {
            _logger.LogInfo("- white rice");
            _logger.LogInfo("- olive oil");
            _logger.LogInfo("- green curry paste");
        }

        protected override void PrintCookingSteps() {
            _logger.LogInfo("- cook the rice");
            _logger.LogInfo("- cook the carrot, onions, and peppers in coconut oil for ~5 minutes");
            _logger.LogInfo("- add garlic and ginger and cook for a minute");
            _logger.LogInfo("- add the curry paste");
            _logger.LogInfo("- add the coconut milk and water");
            _logger.LogInfo("- add the soy sauce and lime juice");
        }

        protected override void PrintOptionalServingSuggestions() {
            _logger.LogInfo("- serve over rice");
            _logger.LogInfo("- serve with a side of chili paste");
        }

    }
}
