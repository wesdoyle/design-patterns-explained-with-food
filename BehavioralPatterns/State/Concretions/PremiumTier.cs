using System.Collections.Generic;
using RealisticDependencies;

namespace BehavioralPatterns.State.Concretions {
    /// <summary>
    /// Implements particular behaviors associated with the state of a Rewards State Context 
    /// </summary>
    public class PremiumTier: RewardsTier {
        private readonly ISendsEmails _emailer;

        public PremiumTier(RewardsTier state, ISendsEmails emailer) :
            this(state.PointBalance, state.Account, emailer) {
            _emailer = emailer;
        }
        
        public PremiumTier(
            int pointsBalance, 
            RewardsAccount account, 
            ISendsEmails emailer) : base(emailer) {
            PointBalance = pointsBalance;
            Account = account;
            Initialize();
        }

        private void Initialize() {
            AvailablePerks = new List<string> {"1 Free Coffee", "1 Free Tea", "1 Free Latte", "1 Free Cappucino"};
        }

        public override void OnPurchase(int points) {
            PointBalance += points;
            RefreshState();
        }

        public override void UsePoints(int points) {
            PointBalance -= points;
            RefreshState();
        }
        
        private void RefreshState() {
            if (PointBalance < Configuration.MinPremiumPointsBalance) {
                Account.RewardsTier = new BasicTier(this, _emailer);
            }
        }
    }
}
