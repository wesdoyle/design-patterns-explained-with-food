using System;
using RealisticDependencies;

namespace BehavioralPatterns.State.Concretions {
    public class VibratingMode: BuzzerMode {
        
        public VibratingMode(IApplicationLogger logger) : base(logger) { }
        
        public override void Activate() {
            Logger.LogInfo(":: Vibrating ::", ConsoleColor.Magenta);
        }
        
        public void TransitionToBuzzingState() {
            Context.TransitionTo(new ConcreteStateB());
        }

    }
}
