using System;

namespace BehavioralPatterns.State.Concretions {
    public class ConcreteStateA : ApplicationState {
        public override void Handle1() {
            Console.WriteLine("ConcreteStateA handles request1.");
            Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            Context.TransitionTo(new ConcreteStateB());
        }

        public override void Handle2() {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }
}
