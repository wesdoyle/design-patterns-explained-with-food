namespace RealisticDependencies.PaymentProcessing {
    public class CreditCardProcessor : IProcessesPayments {
        public string HandlePayment(decimal paymentAmount) {
            return $"Handling Credit Card Payment for amount: {paymentAmount}";
        }
    }
}
