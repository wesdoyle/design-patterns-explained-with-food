using System;
using BehavioralPatterns.State.Concretions;
using RealisticDependencies;

namespace BehavioralPatterns.State {
    public class RewardsAccount {
        private readonly RewardsTier _state;
        private readonly string _patron;
        private readonly IApplicationLogger _logger;
 
        public RewardsAccount(IApplicationLogger logger, ISendsEmails emailer, string patron) {
            _logger = logger;
            _patron = patron;
            RewardsTier = new BasicTier(0, this, emailer);
            _state = new BasicTier(RewardsTier, emailer);
        }
 
        public double PointsBalance => _state.PointBalance;

        // The State
        public RewardsTier RewardsTier { get; set; }

        public string GetPatronEmail() => _patron;

        public void OnPurchase(int points) {
            _state.OnPurchase(points);
            _logger.LogInfo($"You earned {points} points", ConsoleColor.Green);
            _logger.LogInfo($"Current Points= {PointsBalance}", ConsoleColor.Green);
            _logger.LogInfo($"Rewards Status = {RewardsTier.GetType().Name}", ConsoleColor.Green);
            _logger.LogInfo($"-------------------------------");
        }
 
        public void UsePoints(int points) {
            _state.UsePoints(points);
            _logger.LogInfo($"You used {points} points", ConsoleColor.Yellow);
            _logger.LogInfo($"Current Points= {PointsBalance}", ConsoleColor.Yellow);
            _logger.LogInfo($"Rewards Status = {RewardsTier.GetType().Name}", ConsoleColor.Yellow);
            _logger.LogInfo($"-------------------------------");
        }
    }
}