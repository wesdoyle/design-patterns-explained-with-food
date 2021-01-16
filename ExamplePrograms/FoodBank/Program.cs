using System;
using System.Collections.Generic;
using StructuralPatterns.Proxy;

namespace FoodBank {
    class Program {
        private static void Main(string[] args) {
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
