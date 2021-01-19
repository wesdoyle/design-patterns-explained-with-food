using RealisticDependencies;
using System;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator.FoodCarts {
    public class HandCart : FoodCart {
        private readonly IMediator _network;
        private readonly IApplicationLogger _logger;
        private readonly string _handle;

        public HandCart(
            string handle, int lat, int lon, IApplicationLogger logger) 
            : base(logger, handle, lat, lon) {
        }

        public override async Task Receive(NetworkMessage message) {
            await Task.Delay(500);
            var payload = message.Read();
            var sendTime = message.GetTimestamp();
            _logger.LogInfo($"[{_handle}] Received Message at {payload}: ({sendTime})", ConsoleColor.Magenta);
            if (payload.Contains("thanks hand carts")) {
                var returnMessage = new NetworkMessage("sure thing! 👍");
                returnMessage.Sign(this);
                await _network.Broadcast(returnMessage);
            }
        }

        public override async Task Send(ICommunicates receiver, NetworkMessage message) {
            await Task.Delay(500);
            message.Sign(this);
            await _network.DeliverPayload(receiver.Handle, message);
        }
    }
}
