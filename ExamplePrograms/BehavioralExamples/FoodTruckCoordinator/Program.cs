using BehavioralPatterns.Mediator;
using BehavioralPatterns.Mediator.FoodCarts;
using RealisticDependencies;
using System;
using System.Threading.Tasks;

namespace FoodTruckCoordinator {
    internal class Program {
        /// <summary>
        /// We would like to manage our growing network of Food Trucks.
        /// As the trucks park throughout the city, we need a way for them
        /// to coordinate and communicate with each other so that they
        /// don't occupy the same parking spots throughout the city.
        /// We use a Mediator to eliminate mutual dependencies among our network of trucks.
        /// </summary>
        /// <param name="args"></param>
        private static async Task Main() {
            var logger = new ConsoleLogger();
            var bikeDatabase = new Database(Configuration.ConnectionString, logger);
            var truckDatabase = new Database(Configuration.ConnectionString, logger);

            var deliveryNetwork = new FoodCartMediator();

            var tacoTruck = new FoodTruck("Taco Guy", 4, 2, logger, truckDatabase);
            var falafelCart = new BicycleCart("Falafel Cart", 4, 8, logger, bikeDatabase);
            var sushiCart = new BicycleCart("Sushi Cart", 2, 8, logger, bikeDatabase);
            var sandwichCart = new HandCart("Sandwiches", 1, 8, logger);

            await deliveryNetwork.Register(tacoTruck);
            await deliveryNetwork.Register(falafelCart);
            await deliveryNetwork.Register(sushiCart);
            await deliveryNetwork.Register(sandwichCart);

            await tacoTruck.Send(sushiCart, new NetworkMessage(tacoTruck, "Moving to the East Side."));

            await sushiCart.Send(sushiCart, new NetworkMessage(sushiCart, "thanks trucks"));
        }
    }
}
