using System;

namespace BehavioralPatterns.Memento {
    public interface IMemento {
        string GetName();
        string GetState();
        DateTime GetDate();
    }
}
