using System.Collections;

namespace BehavioralPatterns.Iterator {
    public abstract class IteratorAggregate : IEnumerable {
        public abstract IEnumerator GetEnumerator();
    }
}
