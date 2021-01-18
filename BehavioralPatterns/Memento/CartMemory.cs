using System.Collections.Generic;

namespace BehavioralPatterns.Memento {
    public interface IMementoCache {
        void SaveState(Memento memento);
        Memento GetPreviousStateAndUpdateMemory();
    }

    /// <summary>
    /// The "Caretaker" class from the classic Memento example
    /// This class represents the memory as a Stack, as an example.
    /// It might also represent memory as another type of cache,
    /// database, or other data structure depending
    /// on the needs of the application.
    /// </summary>
    public class CartMemory : IMementoCache {
        private Stack<Memento> _memory = new Stack<Memento>();
        public void SaveState(Memento memento) {
            _memory.Push(memento);
        }

        public Memento GetPreviousStateAndUpdateMemory() {
            return _memory.TryPop(out Memento memento) 
                ? memento 
                : null;
        }
    }
}
