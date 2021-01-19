using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BehavioralPatterns.Mediator.FoodCarts;

namespace BehavioralPatterns.Mediator {
    public class FoodCartMediator : IMediator {
        private readonly BicycleCart _bicycleCart;
        private readonly TruckCart _truckCart;

        public FoodCartMediator(BicycleCart bicycleCart, TruckCart truckCart) {
            _bicycleCart = bicycleCart;
            _bicycleCart.SetMediator(this);
            _truckCart = truckCart;
            _truckCart.SetMediator(this);
        }

        public Task Broadcast(NetworkMessage ev) {
            throw new NotImplementedException();
        }

        public Task DeliverPayload(ICommunicates sender, NetworkMessage ev) {
            throw new NotImplementedException();
        }

        public Task DeliverPayload(List<ICommunicates> sender, NetworkMessage ev) {
            throw new NotImplementedException();
        }

        public Task Register(ICommunicates sender) {
            throw new NotImplementedException();
        }
    }
}
