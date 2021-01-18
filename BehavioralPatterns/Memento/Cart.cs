using RealisticDependencies;
using System;

namespace BehavioralPatterns.Memento {
    public interface IShoppingCart {
        void AddDoughnut(string doughnut);
        void PrintState();
        Memento Save();
        void Restore(Memento memento);
    }

    /// <summary>
    /// The Originator creates a Memento - a snapshot of its current internal state.
    /// It can restore its internal state using a Memento.
    /// </summary>
    public class Cart : IShoppingCart {
        private string _state;
        private readonly IApplicationLogger _logger;

        public Cart(IApplicationLogger logger) {
            _logger = logger;
        }

        public void AddDoughnut(string doughnut) {
            _state += $"_{doughnut}";
            _logger.LogInfo("Added a doughnut to the cart.", ConsoleColor.DarkGray);
            Save();
        }

        public void PrintState() => _logger.LogInfo($"{_state}", ConsoleColor.Green);

        // Saves the Cart state in a Memento object.
        public Memento Save() => new CartMemento(_state);

        // Restores the Cart's state from a Memento object.
        public void Restore(Memento memento) {
            if (!(memento is CartMemento)) {
                throw new InvalidOperationException($"Concrete Memento instance required.");
            }
            _state = memento.GetState();
            _logger.LogInfo($"Restored cart to a previous state: {_state}", ConsoleColor.DarkGray);
        }
    }

    public static class Doughnut {
        public static string Vanilla => "vanilla";
        public static string Chocolate => "chocolate";
        public static string Blueberry => "blueberry";
    }
}
