using System;
using BehavioralPatterns.ChainOfResponsibility.Constants;
using RealisticDependencies;

namespace BehavioralPatterns.ChainOfResponsibility.Handlers {
    public class CustomerLoyaltyHandler : AbstractHandler {
        private readonly IApplicationLogger _logger;

        public CustomerLoyaltyHandler(IApplicationLogger logger) {
            _logger = logger;
        }
        
        public override KombuchaSale Handle(KombuchaSale request) {
            if (request.CustomerType == CustomerType.RewardsMember) {
                _logger.LogInfo("Adding rewards point for purchase!", ConsoleColor.Green);
                return base.Handle(request);
            }

            if (request.CustomerType != CustomerType.RewardsMember) {
                _logger.LogInfo("Adding advertisement to request.", ConsoleColor.Green);
                request.SpecialMessages.Add("Have you heard about our Rewards Program?"); 
                return base.Handle(request);
            }

            Console.ResetColor();
            return base.Handle(request);
        }
    }
}
