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
            _logger.LogInfo("Added Doughnut and persisted this event to memory");
        }

        public void Undo() {
            var memento = _caretaker.GetPreviousStateAndUpdateMemory();
            _cart.Restore(memento);
            _logger.LogInfo("Restored Cart to Previous State");
        }

        public void Print() => _cart.PrintState();
    }
}
