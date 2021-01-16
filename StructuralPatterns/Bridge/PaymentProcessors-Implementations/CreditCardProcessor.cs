namespace StructuralPatterns.Bridge {
    public class CreditCardProcessor : IProcessesPayments {
        public string HandlePayment(decimal paymentAmount) {
            return "Concrete Implementation A: The result in platform B.";
        }
    }
}
