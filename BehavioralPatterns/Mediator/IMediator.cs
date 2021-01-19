using System.Collections.Generic;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public interface IMediator {
        public Task Register(FoodCart member);
        public Task DeliverPayload(string handle, NetworkMessage message);
        public Task DeliverPayload(List<FoodCart> receivers, NetworkMessage message);
        public Task Broadcast(NetworkMessage message);
    }
}
