using System;
using RealisticDependencies.PaymentProcessing;

namespace StructuralPatterns.Bridge.Vendors
{
    // The Abstraction can be extended without changing the implementation classes
    public class Florist : FarmersMarketVendor
    {

        public Florist(IProcessesPayments paymentProcessor) : base(paymentProcessor)
        { }

        public override string ProcessCustomerPayment(decimal payment, string vendorName)
        {
            Console.WriteLine($"Florist: {vendorName} is processing " +
                              $"a ${payment} payment for a vial of lavender oil");
            return _paymentProcessor.HandlePayment(payment);
        }
    }
}
