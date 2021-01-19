using RealisticDependencies;
using System;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public abstract class FoodCart : ICommunicates {
        protected IMediator Mediator;
        protected IApplicationLogger Logger;
        protected int Latitude;
        protected int Longitude;
        public string Handle { get; }

        public FoodCart(IApplicationLogger logger, string handle, int lat, int lon) 
            => (Logger, Handle, Latitude, Longitude) = (logger, handle, lat, lon);

        protected FoodCart(IMediator mediator = null) => Mediator = mediator;

        public abstract Task Receive(NetworkMessage message);

        public abstract Task Send(ICommunicates foodCart, NetworkMessage message);

        public void SetMediator(IMediator mediator) => Mediator = mediator;

        public async Task SignalLocation() {
            await Task.Delay(250);
            Logger.LogInfo($"[{Latitude} : {Longitude}]", ConsoleColor.Cyan);
        }

        public async Task RegisterWithNetwork(IMediator networkInterface) 
            => await Task.Run(() => Mediator = networkInterface);
    }
}
