using System;
using System.Collections.Generic;

namespace StructuralPatterns.Proxy {
    public class FoodBankService : IAcceptFoodBankDonations {
        public FoodBankService(List<string> foodBankCache) {
            FoodBankCache = foodBankCache;
        }

        public List<string> FoodBankCache { get; }

        public void DonateFood(string food) {
            Console.WriteLine($"FoodBank handling request to donate: {food}.");
            FoodBankCache.Add(food);
            Console.WriteLine("Thank you for your donation.");
        }
    }
}
