using System;
using BehavioralPatterns.Command;
using BehavioralPatterns.Command.Commands;
using RealisticDependencies;

namespace ComposterSignUpForm {
    internal class Program {
        /// <summary>
        /// Here we have a form where users can sign up to have a compost truck come and collect
        /// organic food waste from their homes.  The application needs to do some complex logic
        /// behind the scenes when a user signs up, like send emails and queue up messages to an AWS SQS queue, 
        /// where route planning services subscribe to consume data. We use the Command Pattern to encapsulate
        /// requests for these emails and queuing operations, allowing us to set different commands
        /// to be executed at the start and end of any particular business process, and to decouple the objects
        /// that encapsulate the data needed to perform an operation from the executors. Here we set commands
        /// to be executed during the process of signing up our new user for the service.
        /// </summary>
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

            logger.LogInfo($"Thanks, {name}! A compost vehicle will stop to pick up your compost every Saturday", ConsoleColor.Green);

            var newUserHandler = new NewUserHandler(logger);

            // Our SetOnStart and SetOnFinish methods prepare hooks in the business
            // process of signing a user up for service.
            newUserHandler.SetOnStart(new NewCustomerEmailCommand(emailer, name, emailAddress));
            newUserHandler.SetOnFinish(new AddressQueueCommand(cloudQueue, address));

            newUserHandler.SignUpUser();
        }
    }
}
