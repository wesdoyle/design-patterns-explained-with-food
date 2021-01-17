using System;

namespace BehavioralPatterns.State.Concretions {
    public class ConcreteStateB : ApplicationState {
        public override void Handle1() {
            Console.Write("ConcreteStateB handles request1.");
        }

        public override void Handle2() {
            Console.WriteLine("ConcreteStateB handles request2.");
            Console.WriteLine("ConcreteStateB wants to change the state of the context.");
            Context.TransitionTo(new ConcreteStateA());
        }
    }
}
