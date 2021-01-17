using System;

namespace BehavioralPatterns.Observer {
    public class ObserverState {
        public string Message { get; set; } = "DefaultMessage";
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
