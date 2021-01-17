using System;
using BehavioralPatterns.Observer;
using BehavioralPatterns.Observer.Observers;

namespace DietPlanTracker {
    internal class Program {
        private static void Main() {
            Console.WriteLine("------------------------------------------------------------");
            // The client code.
            var subject = new Subject();

            var profileObserver = new ProfileObserver();
            subject.Attach(profileObserver);

            var dietPlanObserver = new DietPlanObserver();
            subject.Attach(dietPlanObserver);

            subject.UpdateEmailAddress();
            subject.UpdateEmailAddress();

            subject.Detach(dietPlanObserver);
            subject.UpdateEmailAddress();
        }
    }
}
