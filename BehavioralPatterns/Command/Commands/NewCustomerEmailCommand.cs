using System;
using RealisticDependencies;

namespace BehavioralPatterns.Command.Commands {
    public class NewCustomerEmailCommand : ICommand {
        private readonly ISendsEmails _emailer;
        private readonly string _name;
        private readonly string _emailAddress;

        public NewCustomerEmailCommand(ISendsEmails emailer, string name, string emailAddress) {
            _emailer = emailer;
            _name = name;
            _emailAddress = emailAddress;
        }

        public void Execute() {
            var payload = $"Hi, {_name}! Welcome to the neighborhood compost group!";
            var email = new EmailMessage(_emailAddress, payload);
            Console.WriteLine($"Sending new customer {_name} a welcome email.");
            _emailer.SendMessage(email);
        }
    }
}
