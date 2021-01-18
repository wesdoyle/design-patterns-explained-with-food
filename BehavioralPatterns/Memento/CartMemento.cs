using System;

namespace BehavioralPatterns.Memento {
    /// <summary>
    /// Provides a "Snapshot" that can be used by a DoughnutShoppingCart
    /// to restore its state.
    /// </summary>
    public class CartMemento : Memento {

        private readonly string _state;
        private readonly DateTime _date;

        public CartMemento(string state) {
            // Serves as a container for state with current time on creation
            _date = DateTime.UtcNow;
            _state = state;
        }

        public override string GetState() => _state;

        public override DateTime GetSnapshotDate() => _date;
    }
}
