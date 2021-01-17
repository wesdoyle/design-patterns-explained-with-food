namespace BehavioralPatterns.Visitor {
    public interface IVisitable<in T> where T: Report {
        Report Accept(IVisitor<T> visitor);
    }
}
