using System;

namespace BehavioralPatterns.Visitor {
    public abstract class Report {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public abstract void Print();
    }
}
