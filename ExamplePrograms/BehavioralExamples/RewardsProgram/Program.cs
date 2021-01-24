using BehavioralPatterns.State;
using RealisticDependencies;

namespace RewardsProgram {
    internal static class Program {
        static void Main() {
            var logger = new ConsoleLogger();
            var emailer = new Emailer(logger);
            
            logger.LogInfo("☕ Welcome to the Cafe Rewards Program");
            logger.LogInfo("--------------------------------------");
            
            // Sign up for the Rewards Program 
            var rewards = new RewardsAccount(logger, emailer, "Katrina");
 
            logger.LogInfo("Simulating Customer Activity");
            logger.LogInfo("--------------------------------------");
            // Simulate Customer Activity 
            rewards.OnPurchase(1);
            rewards.OnPurchase(1);
            rewards.OnPurchase(1);
            rewards.OnPurchase(1);
            rewards.UsePoints(2);
            rewards.UsePoints(1);
        }
    }
}
