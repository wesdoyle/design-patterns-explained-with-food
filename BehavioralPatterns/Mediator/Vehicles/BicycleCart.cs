using System;
using System.Threading.Tasks;
using RealisticDependencies;

namespace BehavioralPatterns.Mediator.Vehicles {
    public class BicycleCart : FleetMember {
        private readonly IDatabase _database;

        public BicycleCart(
            string handle, 
            int lat, 
            int lon, 
            IApplicationLogger logger, 
            IDatabase database) : base(logger, handle, lat, lon) {
            _database = database;
            _database.Connect().Wait();
        }

        public override async Task Receive(NetworkMessage message) {
            await Task.Delay(500);
            var payload = message.Read();
            var sendTime = message.GetTimestamp();
            Logger.LogInfo($"[{Handle}] Received Message {payload} at ({sendTime})", ConsoleColor.DarkCyan);
            if (payload.Contains("thanks bikes")) {
                var returnMessage = new NetworkMessage("OK! 🚀");
                returnMessage.Sign(this);
                await Mediator.Broadcast(returnMessage);
            }
        }

        public override async Task Send(ICommunicates receiver, NetworkMessage message) {
            await Task.Delay(500);
            message.Sign(this);
            await Mediator.DeliverPayload(receiver.Handle, message);
        }

        public override void SetMediator(IMediator mediator) {
            Logger.LogInfo($"[{Handle}] Registering with Fleet.", ConsoleColor.DarkCyan);
            Mediator = mediator;
        }
    }
}
