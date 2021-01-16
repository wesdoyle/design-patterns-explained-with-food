using System;

namespace StructuralPatterns.Bridge {
    public class VegetableFarmer : FarmersMarketVendor {
        private readonly IProcessesPayments _paymentProcessor;

        public VegetableFarmer(IProcessesPayments paymentProcessor) : base(paymentProcessor) {
            _paymentProcessor = paymentProcessor;
        }

        public override string ProcessCustomerPayment(int payment) {
            Console.WriteLine("Vegetable Farmer is processing a payment for a bag of organic carrots");
            return _paymentProcessor.HandlePayment(payment);
        }
    }
}
