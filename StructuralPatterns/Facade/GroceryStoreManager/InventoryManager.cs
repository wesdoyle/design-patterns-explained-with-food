using System;
using System.Threading;
using System.Threading.Tasks;
using RealisticDependencies;

namespace StructuralPatterns.Facade.GroceryStoreManager {
    public interface IInventoryManager {
        Task ProcessCurrentInventoryReport();
        Task UpdateInventory();
    }

    /// <summary>
    /// Mock class to stand in for a complex system for managing a grocery store.
    /// In order to hide the complexity of dealing with these low-level processes,
    /// we can create a facade to work only with what we need as a client.
    /// </summary>
    public class InventoryManager : IInventoryManager {
        private readonly ISendsEmails _emailer;
        private readonly IAmqpQueue _queue;
        private readonly IDatabase _database;
        private readonly IRecipesApi _recipesApi;

        public InventoryManager(
            ISendsEmails emailer,
            IAmqpQueue queue,
            IDatabase database,
            IRecipesApi recipesApi) {
            _emailer = emailer;
            _queue = queue;
            _database = database;
            _recipesApi = recipesApi;
        }

        public async Task ProcessCurrentInventoryReport() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Processing Inventory...");
            Thread.Sleep(1_000);
            Console.WriteLine("Sending Report to buyers...");
            Thread.Sleep(1_000);
            var email = new EmailMessage("buyers@example.com", "inventory report...");
            await _emailer.SendMessage(email);
            Thread.Sleep(500);
            Console.ResetColor();
        }

        public Task UpdateInventory() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Updating Inventory...");
            Thread.Sleep(1_000);
            Console.WriteLine("Persisting Changes to Database...");
            Thread.Sleep(1_000);
            Console.WriteLine("Database updated!");
            Console.ResetColor();
            return Task.CompletedTask;
        }

    }
}