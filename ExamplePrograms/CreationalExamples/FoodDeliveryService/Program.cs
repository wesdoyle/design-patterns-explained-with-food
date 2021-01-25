using CreationalPatterns.FactoryMethod;
using RealisticDependencies;
using System;
using System.Collections.Generic;

namespace FoodDeliveryService {
    internal class Program {

        /// <summary>
        /// This example uses the Factory Method creational pattern to help fulfill a Food Delivery order
        /// by bicycle or car depending on the input given to the console application.
        /// One of the benefits of this pattern is that it's easier to extend the delivery type construction
        /// code independently from the Main service method here which invokes it.  We could introduce new deliveryTypes
        /// into the project without modifying / breaking our client code - in this case, the Main method.
        /// We've separated the concerns of creating a DeliveryCreator from the client code that uses it.
        /// All of the static data could be extracted from the code into the environment or another configuration source.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static int Main() {
            // Client serves as a simple composition root for dependencies
            var logger = new ConsoleLogger();
            IAmqpQueue deliveryQueue = new CloudQueue(logger);

            logger.LogInfo("🚚  Welcome to the Food Delivery Service!");
            logger.LogInfo("------------------------------------------");
            logger.LogInfo("Please enter a delivery type.");

            // Collect data at runtime which will ultimately determine 
            // the chosen implementation of IDeliversFood
            var deliveryType = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(deliveryType)) {
                logger.LogInfo("Error reading delivery type.");
                return 1;
            }

            try {
                // The client code here deals with business logic at a higher level of abstraction than
                // any of the details related to "how" things actually get delivered.
                // Here we just want to be able to queue up something that delivers food so
                // we can complete our delivery. We can facilitate binding the concrete type as late as possible 
                // by choosing to work with the abstract type here. We don't depend on implementation details - 
                // we depend on abstractions.
                DeliveryCreator deliveryCreator = BuildDeliveryCreator(deliveryType, deliveryQueue);
                deliveryCreator.QueueVehicleForDelivery();

            } catch (Exception e) {
                logger.LogInfo($"There was an error processing the delivery: {e.Message}, {e.StackTrace}");
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Factory Method invoked by the client (our Main method).  This method decides based on data at run-time
        /// which DeliveryCreator type we're eventually binding.  Thanks to (dynamic) polymorphism, the
        /// compiler is cool with us declaring the return type of this method as an abstract type.
        /// even though it will return a concrete subclass.
        /// In this case, the decision of which concrete type will eventually be bound is made by evaluating the 
        /// value of a string `deliveryType` provided by the user of our client.
        /// </summary>
        /// <param name="deliveryType"></param>
        /// <param name="deliveryQueue"></param>
        /// <returns></returns>
        public static DeliveryCreator BuildDeliveryCreator(string deliveryType, IAmqpQueue deliveryQueue) {

            var logger = new ConsoleLogger();

            List<string> validDeliveryOptions = new() { "bicycle", "car" };

            if (!validDeliveryOptions.Contains(deliveryType)) {
                logger.LogInfo("Please enter a type of delivery [bicycle, car]");
                throw new InvalidOperationException("Cannot set up delivery without valid deliveryType.");
            }

            return deliveryType switch {
                "bicycle" => new BicycleDeliveryCreator(deliveryQueue, logger),
                "car" => new CarDeliveryCreator(deliveryQueue, logger),
                _ => throw new InvalidOperationException("Cannot set up delivery without valid Delivery Type."),
            };
        }
    }
}
