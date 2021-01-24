using BehavioralPatterns.Observer;
using BehavioralPatterns.Observer.Observers;
using RealisticDependencies;

namespace DietPlanTracker {
    internal class Program {
        private static void Main() {
            var logger = new ConsoleLogger();
            logger.LogInfo("😅 Welcome to the Diet Plan Client");
            logger.LogInfo("----------------------------------");
                
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
