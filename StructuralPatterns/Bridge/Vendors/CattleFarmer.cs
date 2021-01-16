using System;
using RealisticDependencies.PaymentProcessing;

namespace StructuralPatterns.Bridge.Vendors {
    public class CattleFarmer : FarmersMarketVendor {
        private readonly IProcessesPayments _paymentProcessor;

        public CattleFarmer(IProcessesPayments paymentProcessor) : base(paymentProcessor) {
            _paymentProcessor = paymentProcessor;
        }

        public override string ProcessCustomerPayment(decimal payment, string vendorName) {
            Console.WriteLine($"CattleFarmer: {vendorName} is processing " +
                              $"a ${payment} payment for grass-fed short ribs");
            return _paymentProcessor.HandlePayment(payment);
        }
    }
}
