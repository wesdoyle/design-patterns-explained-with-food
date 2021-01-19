using RealisticDependencies;
using System;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator.FoodCarts {
    public class BicycleCart : FoodCart {
        private IMediator _network;
        private readonly IApplicationLogger _logger;
        private readonly IDatabase _database;
        private readonly string _handle;

        public BicycleCart(
            string handle, 
            int lat, 
            int lon, 
            IApplicationLogger logger, 
            IDatabase database) : base(logger, lat, lon) {
            (_handle, _database) = (handle, database);
            _database.Connect().Wait();
        }

        public override async Task Receive(ICommunicates sender, NetworkMessage message) {
            await Task.Delay(500);
            var payload = message.Read();
            var sendTime = message.GetTimestamp();
            _logger.LogInfo($"[{_handle}] Received Message at {payload}: ({sendTime})", ConsoleColor.Magenta);
            if (payload.Contains("thanks hand bikes")) {
                await _network.Broadcast(new NetworkMessage("👍"));
            }
        }

        public override async Task Send(ICommunicates receiver, NetworkMessage message) {
            await Task.Delay(500);
            message.Sign(_handle);
            await _network.DeliverPayload(receiver, message);
        }

    }
}
