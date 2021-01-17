using System;
using System.Collections.Generic;
using StructuralPatterns.Proxy;

namespace FoodBank {
    internal class Program {
        /// <summary>
        /// We have built a new Food Bank donation system that enables patrons to donate food to our Bank.
        /// It's built on pre-existing software called `FoodBankService` that we would like to restrict
        /// access to to accept only the types of foods we need at this Food Bank.  We'd also like the ability
        /// to log before and perhaps after donations are made.  We also want to control access to things
        /// like the current inventory managed by the underlying FoodBank service.
        /// Here we use the Proxy design pattern to create a level of indirection between this client and
        /// the underlying FoodBankService instance.  This is similar to the implementation of the Decorator
        /// Pattern - However, the Decorator Pattern is used to add behavior to an existing object, whereas
        /// the motivation for the Proxy is to control access to an underlying object.
        /// </summary>
        private static void Main() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("💗 Welcome to the East Side Food Bank");

            var initialFoodBank = new List<string>();
            var foodBankService = new FoodBankService(initialFoodBank);
            var acceptableDonationHandler = new EastSideFoodBank(foodBankService);

            while (true) {
                Console.WriteLine("Please specify what you would like to donate.");
                var donation = Console.ReadLine();
                acceptableDonationHandler.DonateFood(donation);

                Console.WriteLine("Have you completed your total donation? (y/n)");
                var isComplete = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(isComplete) || isComplete.ToLower() != "y") continue;
                var bankCache = acceptableDonationHandler.GetBankCache();
                if (bankCache.Count > 0) {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Thank you for your donation(s).");
                    Console.WriteLine("The Bank now contains the following items:");
                    foreach (var foodItem in bankCache) {
                        Console.WriteLine($"🥕 {foodItem}");
                    }
                    Console.ResetColor();
                }

                Console.WriteLine("Have a nice day.");
                break;
            }
        }
    }
}
