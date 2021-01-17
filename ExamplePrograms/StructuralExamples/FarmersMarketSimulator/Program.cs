using System;
using RealisticDependencies.PaymentProcessing;
using StructuralPatterns.Bridge.Vendors;

namespace FarmersMarketSimulator {
    internal class Program {
        /// <summary>
        /// This example uses the Bridge Pattern to separate high-level abstractions from implementation details.
        /// We have a Farmers Market, where different types of vendors process payments using different
        /// types of Payment Processing services, including credit cards and gift cards.
        /// The "Bridge" is the has-a relationship between vendors and their payment processors.
        /// Any FarmersMarketVendor has an object that implements the IProcessesPayments interface.
        /// Because every concrete FarmersMarketVendor is programmed to work with the high-level IProcessesPayments interface,
        /// the vendor logic can be extended independently of the implementations of the Payment Processors.  Likewise,
        /// the implementors of IProcessesPayments know nothing about the context in which they are used, and can be treated like a plugin.
        /// in fact, they can be used in many other contexts, so they've been extracted to the RealisticDependencies class library.
        /// By using object composition in this way, we avoid creating an exponential explosion in a potential
        /// subclass hierarchy for specific vendor-processor combinations. 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static void Main(string[] args) {
            Console.WriteLine("🧑‍🌾  Welcome to the Farmer's Market!");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const string organicGardens = "Organic Gardens";
            const string olsenFarm = "Olsen Farm";
            const string andersenFarm = "Andersen Farm";
            const string pleasantValley = "Pleasant Valley";
            const string hillsideRanch = "Hillside Ranch";

            var creditCardProcessor = new CreditCardProcessor();
            var giftCardProcessor = new GiftCardProcessor();

            var booth1 = new VegetableFarmer(creditCardProcessor);
            var booth2 = new VegetableFarmer(giftCardProcessor);
            var booth3 = new CattleFarmer(creditCardProcessor);
            var booth4 = new Florist(creditCardProcessor);
            var booth5 = new Florist(giftCardProcessor);

            booth1.ProcessCustomerPayment(10.00m, organicGardens);
            booth1.ProcessCustomerPayment(12.00m, organicGardens);
            booth1.ProcessCustomerPayment(1.50m, organicGardens);

            booth2.ProcessCustomerPayment(15.50m, olsenFarm);

            booth3.ProcessCustomerPayment(5.00m, andersenFarm);
            booth3.ProcessCustomerPayment(5.00m, andersenFarm);
            booth3.ProcessCustomerPayment(5.00m, andersenFarm);

            booth4.ProcessCustomerPayment(12.00m, pleasantValley);
            booth4.ProcessCustomerPayment(11.00m, pleasantValley);

            booth5.ProcessCustomerPayment(12.00m, hillsideRanch);
        }
    }
}
