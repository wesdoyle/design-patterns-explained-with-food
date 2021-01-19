using System;

namespace BehavioralPatterns.Mediator {
    public class NetworkMessage {
        public NetworkMessage(string payload) => (_payload) = (payload);

        private DateTime _timeSent = DateTime.UtcNow;

        private ICommunicates _from;

        private string _payload;

        public string GetTimestamp() => _timeSent.ToString("T");

        public ICommunicates GetSender() => _from;

        public string Read() => _payload;

        public void Sign(ICommunicates signature) {
            _from = signature;
            _payload = $"<@{signature.Handle} : {_payload}>";
        }
    }
}
