using System;
using System.Net.Cache;
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
            var emailer = new Emailer();

            var cartonizer = new Cartonizer();
            var customerLoyalty = new CustomerLoyaltyHandler();
            var receiptPrinter = new ReceiptPrinter(emailer);
            var shippingLabeler = new ShippingLabelPrinter();

            cartonizer
                .SetNext(customerLoyalty)
                .SetNext(shippingLabeler)
                .SetNext(receiptPrinter);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Process: Cartonize > Loyalty Program > Shipping Labels > Receipt");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();

            var request = new KombuchaSale(); 

            Console.WriteLine("Are you a rewards member? (y/n)");
            var isRewardsMember = Console.ReadLine();
            if (isRewardsMember != null && isRewardsMember.ToLower() == "y") {
                request.CustomerType = CustomerType.RewardsMember;
            } else {
                request.CustomerType = CustomerType.WalkIn;
            }

            Console.WriteLine("Is this an online order? (y/n)");
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
