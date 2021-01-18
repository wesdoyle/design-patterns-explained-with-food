using RealisticDependencies;
using System.Collections.Generic;

namespace BehavioralPatterns.Strategy {
    public class Context {
        /// <summary>
        /// This Context works with a Strategy via its interface.
        /// It never works with directly with an implementation of IStrategy.
        /// </summary>
        private IMenuGenerationStrategy _strategy;

        private readonly IApplicationLogger _logger;
        private readonly IDateTimeProvider _date;

        public Context() { }

        public Context(
            IMenuGenerationStrategy strategy, 
            IApplicationLogger logger, 
            IDateTimeProvider date) {
            _strategy = strategy;
            _logger = logger;
            _date = date;
        }

        public void SetStrategy(IMenuGenerationStrategy strategy) {
            _strategy = strategy;
        }

        // The Context delegates some work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public void PublishMenu() {
            _logger.LogInfo("Generating the Menu.");

            var currentMenu = _strategy.GenerateMenu(_date.GetCurrentTimeUtc());

            foreach (var item in currentMenu.MenuItems) {
                _logger.LogInfo(
                    $"- {item.Name} | {item.Description} | {item.Price}}",
                    System.ConsoleColor.Cyan);
            }
        }
    }
}
