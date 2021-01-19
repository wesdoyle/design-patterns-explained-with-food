using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator {
    public class FoodCartMediator : IMediator {

        private Dictionary<string, ICommunicates> _fleet;

        /// <summary>
        /// We could initialize the mediator with a collection of ICommunicators
        /// </summary>
        public FoodCartMediator() { }

        public async Task Broadcast(NetworkMessage message) {
            foreach (var member in _fleet) {
                await member.Value.Receive(message);
            }
        }

        public async Task DeliverPayload(string handle, NetworkMessage message) {
            if (!_fleet.ContainsKey(handle)) {
                return;
            }
            await _fleet[handle].Receive(message);
        }

        public async Task DeliverPayload(List<FoodCart> receivers, NetworkMessage message) {
            foreach (var member in receivers) {
                if (_fleet.ContainsKey(member.Handle)) {
                    await member.Receive(message);
                }
            }
        }

        public async Task Register(ICommunicates fleetMember) {
            await Task.Delay(250);
            if (!_fleet.ContainsKey(fleetMember.Handle)) {
                _fleet[fleetMember.Handle] = fleetMember;
            }
            fleetMember.SetMediator(this);
        }

        public Task Register(FoodCart member) {
            throw new NotImplementedException();
        }
    }
}
