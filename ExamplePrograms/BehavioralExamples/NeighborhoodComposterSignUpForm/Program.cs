using System;
using BehavioralPatterns.Command;
using BehavioralPatterns.Command.Commands;
using RealisticDependencies;

namespace ComposterSignUpForm {
    internal class Program {
        private static void Main() {

            var logger = new ConsoleLogger();
            var cloudQueue = new CloudQueue(logger);
            var emailer = new Emailer(logger);

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            logger.LogInfo("🌱 Welcome to the Neighborhood Composter Sign Up Application");
            logger.LogInfo("------------------------------------------------------------");

            logger.LogInfo("What's your name?");
            var name = Console.ReadLine();

            logger.LogInfo("What's your email address?");
            var emailAddress = Console.ReadLine();

            logger.LogInfo("What's your home address?");
            var address = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            logger.LogInfo($"Thanks, {name}! A compost vehicle will stop to pick up your compost every Saturday");
            Console.ResetColor();

            var newUserHandler = new NewUserHandler();
            newUserHandler.SetOnStart(new NewCustomerEmailCommand(emailer, name, emailAddress));
            newUserHandler.SetOnFinish(new AddressQueueCommand(cloudQueue, address));
            newUserHandler.SignUpUser();
        }
    }
}
