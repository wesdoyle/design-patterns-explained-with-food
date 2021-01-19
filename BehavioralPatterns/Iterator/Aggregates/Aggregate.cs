using System.Collections;

namespace BehavioralPatterns.Iterator.Aggregates {
    public abstract class Aggregate : IEnumerable {
        public abstract IEnumerator GetEnumerator();
    }
}
