using System.Threading;

namespace RealisticDependencies.PaymentProcessing {
    public class GiftCardProcessor : IProcessesPayments {
        public string HandlePayment(decimal paymentAmount) {
            Thread.Sleep(3000);
            return $"Handling Gift Card Payment for amount: {paymentAmount}";
        }
    }
}
