namespace RealisticDependencies.PaymentProcessing {
    public class GiftCardProcessor : IProcessesPayments {
        public string HandlePayment(decimal paymentAmount) {
            return $"Handling Gift Card Payment for amount: {paymentAmount}";
        }
    }
}
