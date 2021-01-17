using CreationalPatterns.AbstractFactory;
using RealisticDependencies;
using System;
using System.Threading.Tasks;
using CreationalPatterns.AbstractFactory.MealPlanFactories;

namespace CustomMealPlanner {
    internal class Program {
        /// <summary>
        /// This example uses the Abstract Factory creational pattern to help fulfill a meal planning application 
        /// for customers who wish to follow a specific type of diet.  Depending on the customer's diet,
        /// a different Meal Plan is generated, which contains methods in this example for generating lunch or dessert menus,
        /// which provide lists of ingredients, meals, and diet summaries.
        /// One of the benefits of this approach is that all of the data associated with a specific diet,
        /// such as the foods involved in meal prep and grocery lists, can belong to specific factories,
        /// increasing the ability to ensure compatibility across the various products of a MealPlanFactory.
        /// One of the downsides of this approach is that it is fairly complex for small use cases, though
        /// it does promote extensibility (Open / Closed principle - open for extension, closed for modification)
        /// if new meal plans are introduced, there is no need clients of the MealPlanService.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task Main(string[] args) {
            var logger = new ConsoleLogger();

            Console.WriteLine("Please enter customer email.");
            var customerEmail = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(customerEmail)) {
                logger.LogInfo("Error reading customer email.");
                return;
            }

            try {
                var dietType = GetCustomerDietFromDatabase(customerEmail);
                var mealPlanFactory = GetFactoryForDietType(dietType);
                ISendsEmails emailer = new Emailer(logger);
                IMealPlanService mealPlanService = new MealPlanService(mealPlanFactory, emailer);
                await mealPlanService.SendDessertsPlanToSubscriber(customerEmail);

            } catch (Exception e) {
                logger.LogError($"{$"Error processing the meal plan: {e.Message}, {e.StackTrace}"}");
                return;
            }

            return;
        }

        public static string GetCustomerDietFromDatabase(string customerEmail) {
            return customerEmail == "jane@example.com" 
                ? "keto" 
                : "vegetarian";
        }

        public static IMealPlanFactory GetFactoryForDietType(string dietType) 
            => dietType switch {
                "keto" => new KetoMealPlanFactory(),
                "vegetarian" => new VegetarianMealPlanFactory(),
                _ => new VegetarianMealPlanFactory()
            };
    }
}
