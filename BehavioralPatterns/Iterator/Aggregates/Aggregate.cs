using System.Collections;

namespace BehavioralPatterns.Iterator {
    public abstract class Aggregate : IEnumerable {
        public abstract IEnumerator GetEnumerator();
    }
}
