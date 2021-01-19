using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public interface ICommunicates {
        public Task Send(ICommunicates receiver, NetworkMessage message);
        public Task Receive(ICommunicates sender, NetworkMessage message);
    }
}
