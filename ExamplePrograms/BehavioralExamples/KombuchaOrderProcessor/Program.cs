using System;
using BehavioralPatterns.ChainOfResponsibility;
using BehavioralPatterns.ChainOfResponsibility.Constants;
using BehavioralPatterns.ChainOfResponsibility.Handlers;
using RealisticDependencies;

namespace KombuchaOrderProcessor {
    internal class Program {
        /// <summary>
        /// We run a company that brews and bottles kombucha. As part of our checkout process, bottles
        /// of the product follow different paths depending on type of sale initiated.
        /// We have several business processes to consider as part of our process,
        /// including accepting in-store and online orders.  We also have an Awards Program which
        /// we'd like to promote to non-Awards members only.  Here we use the Chain of Responsibility
        /// Pattern to process each stage of the sale accordingly.
        /// </summary>
        private static void Main() {
            var logger = new ConsoleLogger();

            logger.LogInfo("🍾 Welcome to the Kombucha Checkout System!");

            var emailer = new Emailer(logger);

            var cartonizer = new Cartonizer(logger);
            var customerLoyalty = new CustomerLoyaltyHandler(logger);
            var receiptPrinter = new ReceiptPrinter(emailer, logger);
            var shippingLabeler = new ShippingLabelPrinter(logger);

            cartonizer
                .SetNext(customerLoyalty)
                .SetNext(shippingLabeler)
                .SetNext(receiptPrinter);

            logger.LogInfo("Process: Cartonize > Loyalty Program > Shipping Labels > Receipt", ConsoleColor.Blue);
            logger.LogInfo("----------------------------------------------------------------", ConsoleColor.DarkBlue);

            var request = new KombuchaSale(); 

            logger.LogInfo("Are you a rewards member? (y/n)", ConsoleColor.Blue);
            var isRewardsMember = Console.ReadLine();
            if (isRewardsMember != null && isRewardsMember.ToLower() == "y") {
                request.CustomerType = CustomerType.RewardsMember;
            } else {
                request.CustomerType = CustomerType.WalkIn;
            }

            logger.LogInfo("Is this an online order? (y/n)", ConsoleColor.Blue);
            var isOnlineOrder = Console.ReadLine();
            if (isOnlineOrder != null && isOnlineOrder.ToLower() == "y") {
                request.SaleType = SaleType.Online;
            } else {
                request.SaleType = SaleType.InHouse;
            }

            cartonizer.Handle(request);
        }
    }
}
