using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RealisticDependencies;

namespace StructuralPatterns.Facade.GroceryStoreManager {
    public interface IVendorNotifier {
        Task NotifyVendorOfCurrentStock(string vendor);
        List<string> GetVendorsForDepartment(string dept);
    }

    public class VendorNotifier : IVendorNotifier {
        private readonly IDatabase _database;
        private readonly ISendsEmails _emailer;

        public VendorNotifier(
            IDatabase database,
            ISendsEmails emailer) {
            _database = database;
            _emailer = emailer;
        }

        public Task NotifyVendorOfCurrentStock(string vendor) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Notifying vendor: {vendor}");
            Console.ResetColor();
            return Task.CompletedTask;
        }

        public List<string> GetVendorsForDepartment(string department) {
            // Could use its own dependencies, like the database

            if (department == "produce") {
                return new List<string> {
                    "Organic Orchards",
                    "McKinnon Farm",
                    "Pleasant Valley Farms"
                };
            }

            return new List<string>();
        }
    }
}