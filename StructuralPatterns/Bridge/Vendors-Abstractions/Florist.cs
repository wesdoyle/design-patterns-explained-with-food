using System;

namespace StructuralPatterns.Bridge {
    // The Abstraction can be extended without changing the implementation classes
    public class Florist : FarmersMarketVendor {
        private readonly IProcessesPayments _paymentProcessor;

        public Florist(IProcessesPayments paymentProcessor) : base(paymentProcessor) {
            _paymentProcessor = paymentProcessor;
        }

        public override string ProcessCustomerPayment(int payment) {
            Console.WriteLine("Florist is processing a payment for a vial of lavender oil");
            return _paymentProcessor.HandlePayment(payment);
        }
    }
}
