namespace BehavioralPatterns.Observer {
    public interface ISubject {
        // Attaches an Observer to the Subject.
        void Attach(IObserver observer);

        // Detaches an Observer from the Subject.
        void Detach(IObserver observer);

        // Notifies all Observers about an Event.
        void Notify();
    }
}
