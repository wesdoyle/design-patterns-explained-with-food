using RealisticDependencies;

namespace BehavioralPatterns.State {
    public abstract class RewardsTier {
        
        protected readonly IApplicationLogger Logger;

        public RewardsTier(IApplicationLogger logger) {
            Logger = logger;
        }
        
        protected RewardsStateContext RewardsStateContext;

        public void SetContext(RewardsStateContext rewardsStateContext) {
            RewardsStateContext = rewardsStateContext;
        }
    }
}
