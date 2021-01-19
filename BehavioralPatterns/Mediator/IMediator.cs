using System.Collections.Generic;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public interface IMediator {
        public Task Register(ICommunicates sender);
        public Task DeliverPayload(ICommunicates sender, NetworkMessage ev);
        public Task DeliverPayload(List<ICommunicates> sender, NetworkMessage ev);
        public Task Broadcast(NetworkMessage ev);
    }
}
