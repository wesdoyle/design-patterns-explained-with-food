using RealisticDependencies;
using System;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public abstract class FleetMember : ICommunicates {
        protected IMediator Mediator;
        protected IApplicationLogger Logger;
        protected int Latitude;
        protected int Longitude;
        public string Handle { get; }

        public FleetMember(IApplicationLogger logger, string handle, int lat, int lon) 
            => (Logger, Handle, Latitude, Longitude) = (logger, handle, lat, lon);

        protected FleetMember(IMediator mediator = null) => Mediator = mediator;

        public abstract Task Receive(NetworkMessage message);

        public abstract Task Send(ICommunicates foodCart, NetworkMessage message);

        public abstract void SetMediator(IMediator mediator);

        public async Task SignalLocation() {
            await Task.Delay(250);
            Logger.LogInfo($"[{Latitude} : {Longitude}]", ConsoleColor.Cyan);
        }
    }
}
