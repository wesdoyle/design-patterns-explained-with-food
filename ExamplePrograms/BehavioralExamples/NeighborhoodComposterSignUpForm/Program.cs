using System;
using System.Net.Sockets;
using BehavioralPatterns.Command;
using BehavioralPatterns.Command.Commands;
using RealisticDependencies;

namespace NeighborhoodComposterSignUpForm {
    internal class Program {
        private static void Main() {
            var cloudQueue = new CloudQueue();
            var emailer = new Emailer();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("🌱 Welcome to the Neighborhood Composter Sign Up Application");
            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("What's your name?");
            var name = Console.ReadLine();

            Console.WriteLine("What's your email address?");
            var emailAddress = Console.ReadLine();

            Console.WriteLine("What's your home address?");
            var address = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Thanks, {name}! A compost vehicle will stop to pick up your compost every Saturday");
            Console.ResetColor();

            var newUserHandler = new NewUserHandler();
            newUserHandler.SetOnStart(new NewCustomerEmailCommand(emailer, name, emailAddress));
            newUserHandler.SetOnFinish(new AddressQueueCommand(cloudQueue, address));
            newUserHandler.SignUpUser();
        }
    }
}
