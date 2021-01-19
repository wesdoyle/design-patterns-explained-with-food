using System.Collections.Generic;
using RealisticDependencies;

namespace BehavioralPatterns.State {
    /// <summary>
    /// The abstract class representing "State"
    /// </summary>
    public abstract class RewardsTier {
        private readonly ISendsEmails _emailer;
        public RewardsTier(ISendsEmails emailer) {
            _emailer = emailer;
        }
        
        protected List<string> AvailablePerks;
        
        public int PointBalance { get; set; }
        public RewardsAccount Account { get; set; }
        
        protected RewardsStateContext RewardsStateContext;

        public void SetContext(RewardsStateContext rewardsStateContext) {
            RewardsStateContext = rewardsStateContext;
        }
        
        public abstract void OnPurchase(int points);
        public abstract void UsePoints(int points);
    }
}
