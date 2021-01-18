using BehavioralPatterns.Memento;
using RealisticDependencies;
using System;
using System.Threading;

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

            // Simulate Customer behavior:
            cartClient.Add(Doughnut.Chocolate);
            cartClient.Add(Doughnut.Vanilla);
            cartClient.Add(Doughnut.Blueberry);

            Thread.Sleep(1_500);
            cartClient.Add(Doughnut.Chocolate);
            Thread.Sleep(1_500);
            cartClient.Add(Doughnut.Chocolate);
            Thread.Sleep(1_000);
            cartClient.Add(Doughnut.Chocolate);
            Thread.Sleep(800);
            cartClient.Add(Doughnut.Chocolate);
            Thread.Sleep(500);
            cartClient.Add(Doughnut.Chocolate);
            Thread.Sleep(2_000);

            logger.LogInfo("Initial Cart:", ConsoleColor.Blue);
            cartClient.Print();

            cartClient.Undo();
            cartClient.Undo();
            cartClient.Undo();

            logger.LogInfo("Final Cart after Undo Operations:", ConsoleColor.Blue);

            cartClient.Print();

            logger.LogInfo("Current Memory Dump:", ConsoleColor.Blue);

            cartClient.GetMemoryDump();
        }
    }
}
