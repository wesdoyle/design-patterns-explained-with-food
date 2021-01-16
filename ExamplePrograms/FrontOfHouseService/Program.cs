using System;
using RealisticDependencies;
using StructuralPatterns.Decorator;
using StructuralPatterns.Decorator.Decorators;

namespace FrontOfHouseService {
    internal class Program {
        private static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("👨‍🍳  Welcome to the Front-of-House Service!");

            bool isEmailCustomer;
            bool isSmsCustomer;

            Console.WriteLine("Do you want to be notified by email when your table is ready? (y/n)");
            var emailOption = Console.ReadLine();

            if (emailOption != null)
                switch (emailOption.ToLower()) {
                    case "y":
                        isEmailCustomer = true;
                        break;
                    case "n":
                        isEmailCustomer = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. please try again");
                        return;
                } else {

                Console.WriteLine("Invalid option. please try again");
                return;
            }

            Console.WriteLine("Do you want to be notified by text when your table is ready? (y/n)");
            var smsOption = Console.ReadLine();

            if (smsOption != null)
                switch (smsOption.ToLower()) {
                    case "y":
                        isSmsCustomer = true;
                        break;
                    case "n":
                        isSmsCustomer = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. please try again");
                        return;
                } else {

                Console.WriteLine("Invalid option. please try again");
                return;
            }

            var notifier = new CustomerNotifier();

            if (isSmsCustomer) {
                var smsNotifier = new SmsMessageDecorator(notifier, new CloudQueue());
                var emailNotifier = new EmailMessageDecorator(smsNotifier, new Emailer());
            }

            if (isEmailCustomer) {
            }
        }
    }
}
