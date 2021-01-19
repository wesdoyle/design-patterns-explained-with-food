using BehavioralPatterns.Mediator;
using RealisticDependencies;
using System.Threading.Tasks;
using BehavioralPatterns.Mediator.Vehicles;

namespace FoodTruckCoordinator {
    internal class Program {
        /// <summary>
        /// We would like to manage our growing network of Food Trucks.
        /// As the trucks park throughout the city, we need a way for them
        /// to coordinate and communicate with each other so that they
        /// don't occupy the same parking spots throughout the city.
        /// We use a Mediator to eliminate mutual dependencies among our network of trucks.
        /// </summary>
        private static async Task Main() {
            var logger = new ConsoleLogger();
            var bikeDatabase = new Database(Configuration.ConnectionString, logger);
            var truckDatabase = new Database(Configuration.ConnectionString, logger);

            var deliveryNetwork = new FoodCartMediator(logger);

            var tacoTruck = new FoodTruck("Taco Truck", 4, 2, logger, truckDatabase);
            var falafelCart = new BicycleCart("Falafel Bicycle", 4, 8, logger, bikeDatabase);
            var sushiCart = new BicycleCart("Sushi Bike", 2, 8, logger, bikeDatabase);
            var sandwichShop = new PopUpShop("Sandwich Pop-Up", 1, 8, logger);

            await deliveryNetwork.Register(tacoTruck);
            await deliveryNetwork.Register(falafelCart);
            await deliveryNetwork.Register(sushiCart);
            await deliveryNetwork.Register(sandwichShop);

            await tacoTruck.Send(sushiCart, new NetworkMessage("Moving to the East Side."));

            await sushiCart.Send(tacoTruck, new NetworkMessage("thanks trucks"));

            await sandwichShop.Send(falafelCart, new NetworkMessage("All done here by the lake!"));

            await falafelCart.Send(falafelCart, new NetworkMessage("thanks bikes!"));
            
            await sandwichShop.Send(falafelCart, new NetworkMessage("where are you, Sandwich Shop?"));
            
            await sandwichShop.Send(tacoTruck, new NetworkMessage("hey Taco Truck where are you?"));
        }
    }
}
