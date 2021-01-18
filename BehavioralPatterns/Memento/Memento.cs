using System;

namespace BehavioralPatterns.Memento {
    /// <summary>
    /// Represents a snapshot of state in time
    /// </summary>
    public abstract class Memento {
        public abstract DateTime GetSnapshotDate();
        public abstract string GetState();
    }
}
