using RealisticDependencies;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory {
    public class MealPlanService {
        private readonly IMealPlanFactory _factory;
        private readonly ISendsEmails _emailer;

        MealPlanService(IMealPlanFactory factory, ISendsEmails emailer) {
            _factory = factory;
            _emailer = emailer;
        }

        public async Task SendLunchPlanToCustomer(string customerEmail) {
            var lunchMenu = _factory.GenerateLunchesMenu();
            lunchMenu.PrintDescription();
            lunchMenu.PrintMenu();
            var ingredients = lunchMenu.GetMenuIngredients();
            var emailBody = string.Join(", ", ingredients);
            var message = new EmailMessage(customerEmail, emailBody);
            await _emailer.SendMessage(message);
        }
    }
}
