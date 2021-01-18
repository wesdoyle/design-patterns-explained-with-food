using BehavioralPatterns.Memento;
using RealisticDependencies;

namespace DonutShop {
    internal class Program {
        protected static void Main() {
            var logger = new ConsoleLogger();
            logger.LogInfo("🍩 Welcome to the Doughnut Shop.  Let's demo our cart client...");

            // The underlying cart representation
            var shoppingCart = new Cart(logger);

            // The implementation of cart memory we'd like to use in our client
            var memory = new CartMemory();

            // This is the object we work with in our program
            var cartClient = new CartClient(shoppingCart, memory, logger);

            cartClient.Add(Doughnut.Chocolate);
            cartClient.Undo();
            cartClient.Undo();
            cartClient.Undo();
            cartClient.Undo();
            cartClient.Undo();
            cartClient.Print();
        }
    }
}
