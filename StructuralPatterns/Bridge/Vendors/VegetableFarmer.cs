using System;
using RealisticDependencies.PaymentProcessing;

namespace StructuralPatterns.Bridge.Vendors
{
    public class VegetableFarmer : FarmersMarketVendor
    {
        public VegetableFarmer(IProcessesPayments paymentProcessor) : base(paymentProcessor)
        { }

        public override string ProcessCustomerPayment(decimal payment, string vendorName)
        {
            Console.WriteLine($"Vegetable Farmer: {vendorName} is processing " +
                              $"a ${payment} for a bag of organic carrots");
            return _paymentProcessor.HandlePayment(payment);
        }
    }
}
