using System.Threading.Tasks;
using BehavioralPatterns.Strategy;
using BehavioralPatterns.Strategy.Strategies;
using RealisticDependencies;

namespace MenuChanger {
    public class Program {
        /// <summary>
        /// Here we have out client code that passes a specific IMenuGenerationStrategy
        /// to the RestaurantMenuContext for buiding a menu.
        /// The client provides a layer of abstraction where the appropriate strategy can
        /// be chosen, while the Context contains logic for carrying out any given strategy.
        /// Each strategy can vary in implementation as long as it fulfills the IMenuGenerationStrategy
        /// interface.
        /// </summary>
        protected static async Task Main() {
            var logger = new ConsoleLogger();
            logger.LogInfo("🌶️ Welcome to the Strategic Menu Changer");
            logger.LogInfo("----------------------------------------");
            
            var dateTimeProvider = new DateTimeProvider();
            var menuDatabase = new Database(Configuration.ConnectionString, logger);

            await using (var context = new RestaurantMenuContext(logger, menuDatabase)) {
                logger.LogInfo("Here's the Current Menu! (Using Time Of Day Menu Strategy)");
                context.SetStrategy(new TimeOfDayMenuStrategy(menuDatabase, dateTimeProvider));
                await context.PublishMenu();

                // We can use another Strategy at run time without using a different context object
                logger.LogInfo("Here's the Current Menu! (Using Price Range Menu Strategy $$$)");
                context.SetStrategy(new PriceRangeMenuStrategy(menuDatabase));
                await context.PublishMenu();
            };
            
            logger.LogInfo("Visit us again soon!");
        }
    }
}
