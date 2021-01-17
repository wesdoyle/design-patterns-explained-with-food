using System.Threading;

namespace RealisticDependencies.PaymentProcessing {
    public class CreditCardProcessor : IProcessesPayments {
        public string HandlePayment(decimal paymentAmount) {
            Thread.Sleep(3000);
            return $"Handling Credit Card Payment for amount: {paymentAmount}";
        }
    }
}
