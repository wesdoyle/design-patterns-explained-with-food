using System;

namespace BehavioralPatterns.State.Concretions {
    /// <summary>
    /// Implements particular behaviors associated with the state of a Context 
    /// </summary>
    public class BuzzingMode: BuzzerMode {
        public override void TransitionToBuzzingState() {
            Console.WriteLine("ConcreteStateA handles request1.");
            Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            Context.TransitionTo(new ConcreteStateB());
        }

        public override void Activate() {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }
}
