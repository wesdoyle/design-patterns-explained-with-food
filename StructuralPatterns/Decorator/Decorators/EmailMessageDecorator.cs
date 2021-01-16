using System;
using System.Threading.Tasks;
using RealisticDependencies;

namespace StructuralPatterns.Decorator.Decorators {
    public class EmailMessageDecorator : NotificationDecorator {

        private readonly ISendsEmails _emailer;

        public EmailMessageDecorator(Notifier component, ISendsEmails emailer) : base(component) {
            _emailer = emailer;
        }

        public override async Task HandleTableReadyMessage() {
            await base.HandleTableReadyMessage();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(":: Email - Preparing an email");
            Console.ResetColor();
            var email = new EmailMessage("customer@example.com", "Your table is ready!");
            await _emailer.SendMessage(email);
        }
    }
}
