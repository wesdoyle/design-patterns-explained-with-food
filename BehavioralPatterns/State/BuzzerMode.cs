using RealisticDependencies;

namespace BehavioralPatterns.State {
    public abstract class BuzzerMode {
        
        protected readonly IApplicationLogger Logger;

        public BuzzerMode(IApplicationLogger logger) {
            Logger = logger;
        }
        
        protected Context Context;

        public void SetContext(Context context) {
            Context = context;
        }

        public abstract void Activate();
        public abstract void MoveToNextState();
    }
}
