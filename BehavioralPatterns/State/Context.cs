using System;

namespace BehavioralPatterns.State {
    /// <summary>
    /// Maintains an instance of a particular Concrete State that defines the current state
    /// </summary>
    public class Context {
        
        private BuzzerMode _mode;

        public Context(BuzzerMode mode) {
            TransitionTo(mode);
        }

        public void TransitionTo(BuzzerMode mode) {
            Console.WriteLine($"Context: Transitioning to {mode.GetType().Name}.");
            _mode = mode;
            _mode.SetContext(this);
        }

        public void Request1() {
            _mode.TransitionToBuzzingState();
        }

        public void Request2() {
            _mode.Activate();
        }
    }
}
