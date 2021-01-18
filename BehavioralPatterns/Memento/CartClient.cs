using RealisticDependencies;

namespace BehavioralPatterns.Memento {
    public class CartClient {
        private readonly IShoppingCart _cart;
        private readonly IMementoCache _caretaker;
        private readonly IApplicationLogger _logger;

        public CartClient(
            IShoppingCart cart,
            IMementoCache caretaker,
            IApplicationLogger logger) {
            _cart = cart;
            _caretaker = caretaker;
            _logger = logger;
        }

        public void Add(string doughnut) {
            _cart.AddDoughnut(doughnut);
            var memento = _cart.Save();
            _caretaker.SaveState(memento);
            _logger.LogInfo($"(Cart Client) Added doughnut and persisted this event to memory: [{doughnut}]");
        }

        public void Undo() {
            var memento = _caretaker.GetPreviousStateAndUpdateMemory();
            if (memento == null) {
                _logger.LogError("(Cart Client) The cart is empty");
                return;
            }
            _cart.Restore(memento);
            _logger.LogInfo("(Cart Client) Restored Cart to previous state");
        }

        public void Print() => _cart.PrintState();
    }
}
