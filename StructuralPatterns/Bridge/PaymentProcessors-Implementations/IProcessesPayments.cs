namespace StructuralPatterns.Bridge {
    // Defines the interface for all implementation classes.
    // It doesn't have to match the Abstraction interface.  In fact,
    // The two can be completely different.  Typically, the implementation
    // interface provides only primitive operations, while the Abstraction
    // defines higher-level operations based on those primitives.
    public interface IProcessesPayments {
        string HandlePayment(decimal paymentAmount);
    }
}
