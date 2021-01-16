using System;
using StructuralPatterns.Facade;

namespace GroceryReporter {
    internal class Program {
        private static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("🛍 Welcome to the Grocery Reporting System");

            var reporter = new DailyReporter();

            // Under the hood, the GroceryStoreManager is completing some complex business logic.
            // Thanks to this facade, we can deal with our business needs at a higher level of
            // abstraction than working with the GroceryStoreManager classes directly in this layer.
            reporter.KickOffProduceReport();
        }
    }
}
