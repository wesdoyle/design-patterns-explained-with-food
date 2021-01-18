using System.Collections;

namespace BehavioralPatterns.Iterator {
    /// <summary>
    /// Here we extend System.Collections IEnumerator,
    /// which defines all the methods we need to iterate
    /// </summary>
    public abstract class Iterator : IEnumerator {
        object IEnumerator.Current => Current();

        // Returns the key of the current element
        public abstract int Key();

        // Returns the current element
        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();

    }
}
