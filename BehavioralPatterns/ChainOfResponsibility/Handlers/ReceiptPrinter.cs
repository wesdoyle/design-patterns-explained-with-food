using System;
using System.Linq;
using BehavioralPatterns.ChainOfResponsibility.Constants;
using RealisticDependencies;

namespace BehavioralPatterns.ChainOfResponsibility.Handlers {
    public class ReceiptPrinter : AbstractHandler {
        private readonly ISendsEmails _emailer;

        public ReceiptPrinter(ISendsEmails emailer) {
            _emailer = emailer;
        }

        public override KombuchaSale Handle(KombuchaSale request) {
            Console.ForegroundColor = ConsoleColor.Green;
            if (request.SaleType == SaleType.InHouse) {
                Console.WriteLine("Printing receipt for in-house order.");
                return base.Handle(request);
            }

            if (request.SaleType != SaleType.Online) return base.Handle(request);

            Console.WriteLine("Emailing receipt for online order.");
            var emailReceipt = new EmailMessage("customer@example.com", "Here's your receipt.");
            if (request.SpecialMessages != null && request.SpecialMessages.Any()) {
                foreach (var message in request.SpecialMessages) {
                    emailReceipt.Content += $"| {message}";
                }
            }

            var emailTask = _emailer.SendMessage(emailReceipt);
            emailTask.Wait();
            Console.ResetColor();
            return base.Handle(request);
        }
    }
}
