using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public interface ICommunicates {
        public Task Send(ICommunicates to, NetworkMessage message);
        public Task Receive(NetworkMessage message);
        public string Handle { get; }
        void SetMediator(IMediator mediator);
    }
}
