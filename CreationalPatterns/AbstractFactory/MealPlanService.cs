using RealisticDependencies;
using System;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory {
    public class MealPlanService : IMealPlanService {
        private readonly IMealPlanFactory _factory;
        private readonly ISendsEmails _emailer;

        public MealPlanService(IMealPlanFactory factory, ISendsEmails emailer) {
            _factory = factory;
            _emailer = emailer;
        }

        public async Task SendDessertsPlanToSubscriber(string subscriberEmail) {
            Console.WriteLine($"--------------------------------------------------------------");
            var lunchMenu = _factory.GenerateDessertsMenu();
            lunchMenu.PrintDescription();
            Console.WriteLine($"== 🍜 Compiling Desserts Menu for Subscriber: {subscriberEmail} ==");
            lunchMenu.PrintMenu();
            var ingredients = lunchMenu.GetMenuIngredients();
            var emailBody = string.Join(", ", ingredients);
            var message = new EmailMessage(subscriberEmail, emailBody);
            Console.WriteLine("== ✈️ Sending Subscriber Email ==");
            await _emailer.SendMessage(message);
            Console.WriteLine($"--------------------------------------------------------------");
        }
    }

    public interface IMealPlanService {
        public Task SendDessertsPlanToSubscriber(string customerEmail);
    }
}
