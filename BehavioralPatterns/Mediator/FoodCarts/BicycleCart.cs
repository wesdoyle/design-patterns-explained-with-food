using System;

namespace BehavioralPatterns.Mediator.FoodCarts {
    public class BicycleCart : FoodCart {
        public void DoA() {
            Console.WriteLine("Component 1 does A.");

            Mediator.Notify(this, "A");
        }

        public void DoB() {
            Console.WriteLine("Component 1 does B.");

            Mediator.Notify(this, "B");
        }
    }
}
