using System;
using System.Threading.Tasks;
using RealisticDependencies;

namespace BehavioralPatterns.Mediator.Vehicles {
    public class PopUpShop : FleetMember {

        public PopUpShop(
            string handle, int lat, int lon, IApplicationLogger logger) 
            : base(logger, handle, lat, lon) {
        }

        public override async Task Receive(NetworkMessage message) {
            await Task.Delay(500);
            var payload = message.Read();
            var sendTime = message.GetTimestamp();
            Logger.LogInfo($"[{Handle}] Received Message {payload} at ({sendTime})", ConsoleColor.DarkYellow);
            if (payload.Contains("thanks hand carts")) {
                var returnMessage = new NetworkMessage("All Good! 🌿");
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
            Logger.LogInfo($"[{Handle}] Registering with Fleet.", ConsoleColor.DarkYellow);
            Mediator = mediator;
        }
    }
}
