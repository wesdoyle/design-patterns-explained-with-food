using System;
using RealisticDependencies;

namespace BehavioralPatterns.Command.Commands {
    public class NewCustomerEmailCommand : ICommand {
        private readonly IApplicationLogger _logger;
        private readonly ISendsEmails _emailer;
        private readonly string _name;
        private readonly string _emailAddress;

        public NewCustomerEmailCommand(IApplicationLogger logger, ISendsEmails emailer, string name, string emailAddress) {
            _logger = logger;
            _emailer = emailer;
            _name = name;
            _emailAddress = emailAddress;
        }

        public void Execute() {
            var payload = $"Hi, {_name}! Welcome to the neighborhood compost group!";
            var email = new EmailMessage(_emailAddress, payload);
            _logger.LogInfo($"Sending new customer {_name} a welcome email.", ConsoleColor.Blue);
            _emailer.SendMessage(email);
        }
    }
}
