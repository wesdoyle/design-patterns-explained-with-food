using System;
using BehavioralPatterns.ChainOfResponsibility.Constants;

namespace BehavioralPatterns.ChainOfResponsibility.Handlers {
    public class CustomerLoyaltyHandler : AbstractHandler {
        public override KombuchaSale Handle(KombuchaSale request) {
            Console.ForegroundColor = ConsoleColor.Green;
            if (request.CustomerType == CustomerType.RewardsMember) {
                Console.WriteLine("Adding awards point for purchase!");
                return base.Handle(request);
            }

            if (request.CustomerType != CustomerType.RewardsMember) {
                Console.WriteLine("Adding advertisement to request.");
                request.SpecialMessages.Add("Have you heard about our Awards Program?"); 
                return base.Handle(request);
            }

            Console.ResetColor();
            return base.Handle(request);
        }
    }
}
