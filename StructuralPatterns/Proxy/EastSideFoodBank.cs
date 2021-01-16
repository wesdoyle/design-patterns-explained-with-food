using System;
using System.Collections.Generic;

namespace StructuralPatterns.Proxy {
    public class EastSideFoodBank : IAcceptFoodBankDonations {
        private readonly FoodBankService _foodBank;

        private readonly List<string> _unacceptableItems = new() {
            "candy", "alcohol", "tobacco", "dairy"
        };

        public EastSideFoodBank(FoodBankService foodBank) {
            _foodBank = foodBank;
        }

        public void DonateFood(string food) {
            // Evaluate Access to the Proxied Resource 
            if (!CheckDonationAcceptable(food)) {
                LogUnacceptableDonation(food);
                return;
            }

            // Grant access to the Proxied Resource
            LogAcceptableDonation(food);
            _foodBank.DonateFood(food);

            // Could add post-donation logic here
        }

        public List<string> GetBankCache() {
            LogCacheReadRequest();
            return _foodBank.FoodBankCache;
        }

        private static void LogAcceptableDonation(string food) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DateTime.UtcNow} | EastSideFoodBank Reporting Request to Donate : {food}");
            Console.ResetColor();
        }

        private static void LogUnacceptableDonation(string invalidItem) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.UtcNow} | EastSideFoodBank Reporting Request to Donate : {invalidItem}");
            Console.WriteLine($"Sorry, we cannot accept donations of {invalidItem} at this time.");
            Console.ResetColor();
        }

        private static void LogCacheReadRequest() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{DateTime.UtcNow} | EastSideFoodBank Reporting Access to Cache Read");
            Console.ResetColor();
        }

        private bool CheckDonationAcceptable(string food) {
            return !_unacceptableItems.Contains(food);
        }
    }
}
