using System;

namespace StructuralPatterns.Bridge {
    public class CattleFarmer : FarmersMarketVendor {
        private readonly IProcessesPayments _paymentProcessor;

        public CattleFarmer(IProcessesPayments paymentProcessor) : base(paymentProcessor) {
            _paymentProcessor = paymentProcessor;
        }

        public override string ProcessCustomerPayment(int payment) {
            Console.WriteLine("CattleFarmer is processing a payment for grass-fed short ribs");
            return _paymentProcessor.HandlePayment(payment);
        }
    }
}
