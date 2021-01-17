using System;

namespace BehavioralPatterns.Mediator.FoodCarts {
    public class BicycleCart : FoodCart {
        public void DoA() {
            Console.WriteLine("Component 1 does A.");

            _mediator.Notify(this, "A");
        }

        public void DoB() {
            Console.WriteLine("Component 1 does B.");

            _mediator.Notify(this, "B");
        }
    }
}
