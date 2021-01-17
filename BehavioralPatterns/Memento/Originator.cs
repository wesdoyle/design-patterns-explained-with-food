using System;
using System.Threading;

namespace BehavioralPatterns.Memento {
    /// <summary>
    /// Holds important state that might change over time.
    /// Defines methods for saving and retrieving state using a memento
    /// </summary>
    public class Originator {
        private string _state;

        public Originator(string state) {
            _state = state;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Original State: {state}");
            Console.ResetColor();
        }

        public void DoSomething() {
            Console.WriteLine("Originator: I'm doing something important.");
            _state = GenerateRandomString(30);
            Console.WriteLine($"Originator: and my state has changed to: {_state}");
        }

        private static string GenerateRandomString(int length = 10) {
            const string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = string.Empty;

            while (length > 0) {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];
                Thread.Sleep(12);
                length--;
            }

            return result;
        }

        // Saves the current state inside a memento.
        public IMemento Save() {
            return new ConcreteMemento(_state);
        }

        // Restores the Originator's state from a memento object.
        public void Restore(IMemento memento) {
            if (!(memento is ConcreteMemento)) {
                throw new Exception("Unknown memento class " + memento);
            }

            _state = memento.GetState();
            Console.Write($"Originator: My state has changed to: {_state}");
        }
    }
}
