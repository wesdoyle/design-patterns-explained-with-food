using System;

namespace BehavioralPatterns.State {
    /// <summary>
    /// Maintains an instance of a particular Concrete State that defines the current state
    /// </summary>
    public class RewardsStateContext {
        
        private RewardsTier _mode;

        public RewardsStateContext(RewardsTier mode) {
            TransitionTo(mode);
        }

        public void TransitionTo(RewardsTier mode) {
            Console.WriteLine($"Context: Transitioning to {mode.GetType().Name}.");
            _mode = mode;
            _mode.SetContext(this);
        }
    }
}
