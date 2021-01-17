namespace BehavioralPatterns.Visitor {
    public interface IVisitable {
        void Accept(IVisitor visitor);
    }
}
