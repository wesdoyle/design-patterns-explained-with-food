using Newtonsoft.Json;
using RealisticDependencies;
using System;
using System.Text.Json;

namespace CreationalPatterns.FactoryMethod {
    // Creator class.  This class declares the factory method `RegisterVehicle` 
    // that returns an IDeliversFood object
    public abstract class DeliveryCreator {
        private readonly IAmqpQueue _deliveryQueue;

        public DeliveryCreator() { }

        public DeliveryCreator(IAmqpQueue deliveryQueue) {
            _deliveryQueue = deliveryQueue;
        }

        // We could provide a default concrete implementation here if we wanted, too!
        protected abstract IDeliversFood RegisterVehicle();

        public void QueueVehicleForDelivery() {
            var vehicle = RegisterVehicle();
            var vehiclePayload = JsonConvert.SerializeObject(vehicle);
            var queueMessage = new QueueMessage(vehiclePayload);
            _deliveryQueue.Add(queueMessage);
            Console.WriteLine($"Queued up vehicle of type {vehicle.GetType()} for food delivery.");
        }
    }
}
