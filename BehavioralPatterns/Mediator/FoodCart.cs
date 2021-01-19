using RealisticDependencies;
using System;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public abstract class FoodCart : ICommunicates {
        protected IMediator Mediator;
        protected IApplicationLogger Logger;
        protected int Latitude;
        protected int Longitude;

        public FoodCart(IApplicationLogger logger, int lat, int lon) 
            => (Logger, Latitude, Longitude) = (logger, lat, lon);

        protected FoodCart(IMediator mediator = null) => Mediator = mediator;

        public abstract Task Receive(ICommunicates sender, NetworkMessage message);

        public abstract Task Send(ICommunicates receiver, NetworkMessage message);

        public void SetMediator(IMediator mediator) 
            => Mediator = mediator;

        public async Task SignalLocation() {
            await Task.Delay(250);
            Logger.LogInfo($"[{Latitude} : {Longitude}]", ConsoleColor.Cyan);
        }

        public async Task RegisterWithNetwork(IMediator networkInterface) 
            => await Task.Run(() => Mediator = networkInterface);
    }
}
