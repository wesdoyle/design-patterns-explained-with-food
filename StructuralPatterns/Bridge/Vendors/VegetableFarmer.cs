using System;
using RealisticDependencies.PaymentProcessing;

namespace StructuralPatterns.Bridge.Vendors {
    public class VegetableFarmer : FarmersMarketVendor {
        private readonly IProcessesPayments _paymentProcessor;

        public VegetableFarmer(IProcessesPayments paymentProcessor) : base(paymentProcessor) {
            _paymentProcessor = paymentProcessor;
        }

        public override string ProcessCustomerPayment(decimal payment, string vendorName) {
            Console.WriteLine($"Vegetable Farmer: {vendorName} is processing " +
                              $"a ${payment} for a bag of organic carrots");
            return _paymentProcessor.HandlePayment(payment);
        }
    }
}
