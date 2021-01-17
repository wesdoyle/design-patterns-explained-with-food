namespace BehavioralPatterns.ChainOfResponsibility {
    public interface IHandler {
        KombuchaSale Handle(KombuchaSale request);
        IHandler SetNext(IHandler handler);
    }
}
