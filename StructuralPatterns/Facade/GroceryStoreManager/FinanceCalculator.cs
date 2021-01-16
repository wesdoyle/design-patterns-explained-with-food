using System;
using System.Threading.Tasks;

namespace StructuralPatterns.Facade.GroceryStoreManager {
    public interface IFinanceCalculator {
        Task CalculateMonthTotalRevenue();
        Task CalculateMonthTotalRevenueForVendor(string vendor);
    }

    public class FinanceCalculator : IFinanceCalculator {
        public Task CalculateMonthTotalRevenue() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Calculated revenue for the month");
            Console.ResetColor();
            return Task.CompletedTask;
        }

        public Task CalculateMonthTotalRevenueForVendor(string vendor) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Calculated revenue for the month for {vendor}: $100");
            Console.ResetColor();
            return Task.CompletedTask;
        }
    }
}