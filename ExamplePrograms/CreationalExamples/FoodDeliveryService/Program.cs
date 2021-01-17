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
        private static int Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("🚚  Welcome to the Food Delivery Service!");
            Console.WriteLine("Please enter a delivery type.");

            var deliveryType = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(deliveryType)) {
                Console.WriteLine("Error reading delivery type.");
                return 1;
            }

            try {
                IAmqpQueue deliveryQueue = new CloudQueue();
                var deliveryCreator = BuildDeliveryCreator(deliveryType, deliveryQueue);
                deliveryCreator.QueueVehicleForDelivery();

            } catch (Exception e) {
                Console.WriteLine($"There was an error processing the delivery: {e.Message}, {e.StackTrace}");
                return 1;
            }

            return 0;
        }

        public static DeliveryCreator BuildDeliveryCreator(string deliveryType, IAmqpQueue deliveryQueue) {

            List<string> validDeliveryOptions = new List<string> { "bicycle", "car" };

            if (!validDeliveryOptions.Contains(deliveryType)) {
                Console.WriteLine("Please enter a type of delivery [bicycle, car]");
                throw new InvalidOperationException("Cannot set up delivery without valid deliveryType.");
            }

            if (deliveryType == "bicycle") {
                return new BicycleDeliveryCreator(deliveryQueue);
            }

            if (deliveryType == "car") {
                return new CarDeliveryCreator(deliveryQueue);
            }

            throw new InvalidOperationException("Cannot set up delivery without valid deliveryType.");
        }
    }
}
