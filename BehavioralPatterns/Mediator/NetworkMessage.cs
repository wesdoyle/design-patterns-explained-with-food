using System;

namespace BehavioralPatterns.Mediator {
    public class NetworkMessage {
        public NetworkMessage(string payload) => _payload = payload;
        private DateTime _timeSent = DateTime.UtcNow;
        private string _payload;
        public string GetTimestamp() => _timeSent.ToString("T");
        public string Read() => _payload;
        public string Sign(string signature) => _payload = $"{signature} : {_payload}";
    }
}
