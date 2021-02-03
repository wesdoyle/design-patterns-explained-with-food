namespace BehavioralPatterns.ChainOfResponsibility {
    public abstract class AbstractStep : IHandler {

        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler) {
            _nextHandler = handler;
            return handler;
        }

        public virtual KombuchaSale Handle(KombuchaSale request) {
            return _nextHandler?.Handle(request);
        }
    }
}
