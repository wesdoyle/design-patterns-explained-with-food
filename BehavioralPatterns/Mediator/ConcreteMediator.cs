using System;
using BehavioralPatterns.Mediator.FoodCarts;

namespace BehavioralPatterns.Mediator {
    public class ConcreteMediator : IMediator {
        private readonly BicycleCart _bicycleCart;
        private readonly TruckCart _truckCart;

        public ConcreteMediator(BicycleCart bicycleCart, TruckCart truckCart) {
            _bicycleCart = bicycleCart;
            _bicycleCart.SetMediator(this);
            _truckCart = truckCart;
            _truckCart.SetMediator(this);
        }

        public void Notify(object sender, string ev) {
            if (ev == "A") {
                Console.WriteLine("Mediator reacts on A and triggers following operations:");
                _truckCart.DoC();
            }

            if (ev == "D") {
                Console.WriteLine("Mediator reacts on D and triggers following operations:");
                _bicycleCart.DoB();
                _truckCart.DoC();
            }
        }
    }
}
