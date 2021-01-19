using RealisticDependencies;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public abstract class FleetMember : ICommunicates {
        protected IMediator Mediator;
        protected readonly IApplicationLogger Logger;
        protected readonly int Latitude;
        protected readonly int Longitude;
        public string Handle { get; }

        public FleetMember(IApplicationLogger logger, string handle, int lat, int lon) 
            => (Logger, Handle, Latitude, Longitude) = (logger, handle, lat, lon);

        public abstract Task Receive(NetworkMessage message);

        public abstract Task Send(ICommunicates foodCart, NetworkMessage message);

        public abstract void SetMediator(IMediator mediator);

        public async Task SignalLocation() {
            await Task.Delay(250);
            var message = new NetworkMessage($"{Handle} Reporting From: [{Latitude}, {Longitude}] 🗺️ ");
            await Mediator.Broadcast( message);
        }
    }
}
