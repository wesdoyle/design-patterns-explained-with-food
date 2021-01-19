using System;

namespace BehavioralPatterns.Mediator {
    public class NetworkMessage {
        public NetworkMessage(
            ICommunicates from, 
            string payload) => (_from, _payload) = (from, payload);

        private DateTime _timeSent = DateTime.UtcNow;

        private ICommunicates _from;

        private string _payload;

        public string GetTimestamp() => _timeSent.ToString("T");

        public ICommunicates GetSender() => _from;

        public string Read() => _payload;

        public string Sign(string signature) => _payload = $"{signature} : {_payload}";
    }
}
