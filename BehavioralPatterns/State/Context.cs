using System;

namespace BehavioralPatterns.State {
    public class Context {
        private ApplicationState _state;

        public Context(ApplicationState state) {
            TransitionTo(state);
        }

        public void TransitionTo(ApplicationState state) {
            Console.WriteLine($"Context: Transitioning to {state.GetType().Name}.");
            _state = state;
            _state.SetContext(this);
        }

        public void Request1() {
            _state.Handle1();
        }

        public void Request2() {
            _state.Handle2();
        }
    }
}
