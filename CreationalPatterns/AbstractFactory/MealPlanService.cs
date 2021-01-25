using RealisticDependencies;
using System;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory {
    public class MealPlanService : IMealPlanService {
        private readonly IMealPlanFactory _factory;
        private readonly ISendsEmails _emailer;
        private readonly IApplicationLogger _logger;

        public MealPlanService(IMealPlanFactory factory, ISendsEmails emailer, IApplicationLogger logger) {
            _factory = factory;
            _emailer = emailer;
            _logger = logger;
        }

        public async Task SendDessertsPlanToSubscriber(string subscriberEmail) {
            _logger.LogInfo($"--------------------------------------------------------------");
            var lunchMenu = _factory.GenerateLunchesMenu();
            var dessertMenu = _factory.GenerateDessertsMenu();
            var shoppingList = _factory.GenerateShoppingList();
            
            lunchMenu.PrintDescription();
            _logger.LogInfo($"== 🍜 Compiling Lunches Menu for Subscriber: {subscriberEmail} ==", ConsoleColor.Cyan);
            lunchMenu.PrintMenu();
            
            dessertMenu.PrintDescription();
            _logger.LogInfo($"== 🍜 Compiling Desserts Menu for Subscriber: {subscriberEmail} ==", ConsoleColor.Cyan);
            dessertMenu.PrintMenu();
            
            var ingredients = shoppingList.MakeShoppingList();
            
            var emailBody = string.Join(", ", ingredients);
            var message = new EmailMessage(subscriberEmail, emailBody);
            
            _logger.LogInfo("== ✈️ Sending Subscriber Email ==", ConsoleColor.Cyan);
            
            await _emailer.SendMessage(message);
            
            _logger.LogInfo($"--------------------------------------------------------------", ConsoleColor.Cyan);
        }
    }

    public interface IMealPlanService {
        public Task SendDessertsPlanToSubscriber(string customerEmail);
    }
}
