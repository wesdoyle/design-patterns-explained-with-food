using System;
using System.Threading;
using System.Threading.Tasks;
using RealisticDependencies;
using StructuralPatterns.Decorator;
using StructuralPatterns.Decorator.Decorators;

namespace FrontOfHouseService {
    internal class Program {
        /// <summary>
        /// Here we use a Decorator Pattern to stack the behavior of different notification agents.
        /// We imagine we have a restaurant that notifies its patrons when a table is ready for them.
        /// In addition to the in-house intercom system, patrons have the option to be notified by Text (SMS)
        /// or Email.  We inherited this system from legacy codebase, and need an easy way to add new
        /// behavior as new modes of communication arise.  The decorator allows us to create a stack of
        /// modes of communication without affecting the behavior of existing objects, in a way that is
        /// easy to compose when multiple options of combining communicating methods are desired.
        /// </summary>
        /// <returns></returns>
        private static async Task Main() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("👨‍🍳 Welcome to the Front-of-House Service!");

            bool isEmailCustomer;
            bool isSmsCustomer;

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Do you want to be notified by email when your table is ready? (y/n)");
            var emailOption = Console.ReadLine();

            if (emailOption != null)
                switch (emailOption.ToLower()) {
                    case "y":
                        Console.WriteLine("OK, we'll send you an email.");
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

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Do you want to be notified by text when your table is ready? (y/n)");
            var smsOption = Console.ReadLine();

            if (smsOption != null)
                switch (smsOption.ToLower()) {
                    case "y":
                        Console.WriteLine("OK, we'll send you text.");
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

            Console.WriteLine("-----------------------------------------------------------------");

            Console.WriteLine("Please wait while we arrange a table for you...");
            Thread.Sleep(3_000);

            Console.WriteLine("Looks like we're just about ready...");
            Thread.Sleep(1_000);

            Notifier notifier = new RestaurantIntercomNotifier();

            if (isSmsCustomer) {
                Console.WriteLine("Adding SMS Decorator");
                notifier = new SmsMessageDecorator(notifier, new CloudQueue());
            }

            if (isEmailCustomer) {
                Console.WriteLine("Adding Email Decorator");
                notifier = new EmailMessageDecorator(notifier, new Emailer());
            }

            await notifier.HandleTableReadyMessage();
        }
    }
}
