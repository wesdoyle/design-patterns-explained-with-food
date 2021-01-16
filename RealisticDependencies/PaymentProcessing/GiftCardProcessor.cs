namespace RealisticDependencies.PaymentProcessing {
    public class GiftCardProcessor : IProcessesPayments {
        public string HandlePayment(decimal paymentAmount) {
            return "Concrete Implementation A: The result in platform A.";
        }
    }
}
