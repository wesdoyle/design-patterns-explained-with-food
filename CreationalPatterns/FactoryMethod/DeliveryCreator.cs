using Newtonsoft.Json;
using RealisticDependencies;

namespace CreationalPatterns.FactoryMethod {
    // Creator class.  This class declares the factory method `RegisterVehicle` 
    // that returns an IDeliversFood object
    public abstract class DeliveryCreator {
        private readonly IAmqpQueue _deliveryQueue;
        protected readonly IApplicationLogger _logger;

        public DeliveryCreator() { }

        public DeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) {
            _deliveryQueue = deliveryQueue;
            _logger = logger;
        }

        // The Factory Method
        // We could provide a default implementation here if we wanted, too!
        protected abstract IDeliversFood RegisterVehicle();

        public void QueueVehicleForDelivery() {
            var vehicle = RegisterVehicle();
            var vehiclePayload = JsonConvert.SerializeObject(vehicle);
            var queueMessage = new QueueMessage(vehiclePayload);
            _deliveryQueue.Add(queueMessage);
            _logger.LogInfo($"Queued up vehicle of type {vehicle.GetType()} for food delivery.");
        }
    }
}
