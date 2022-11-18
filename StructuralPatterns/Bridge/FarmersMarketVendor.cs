using System;
using RealisticDependencies.PaymentProcessing;

namespace StructuralPatterns.Bridge
{
    // Defines the interface for the control part of the two class hierarchies.
    // It maintains a reference to an object of the Implementation hierarchy and
    // delegates all work to this object
    public abstract class FarmersMarketVendor
    {
        protected IProcessesPayments _paymentProcessor;

        protected FarmersMarketVendor(IProcessesPayments paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public virtual string ProcessCustomerPayment(decimal payment, string vendorName)
        {
            throw new NotImplementedException("Please override this method in a concrete implementation");
        }
    }
}
