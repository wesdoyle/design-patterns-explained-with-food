namespace RealisticDependencies.PaymentProcessing {
    public interface IProcessesPayments {
        string HandlePayment(decimal paymentAmount);
    }
}
