using CreationalPatterns.FactoryMethod.VehicleTypes;
using RealisticDependencies;
using System;

namespace CreationalPatterns.FactoryMethod {
    public class BicycleDeliveryCreator : DeliveryCreator {
        public BicycleDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger) : base(deliveryQueue, logger) { }
        /// <summary>
        /// Factory Method for creating a new Bicycle (IDeliversFood implementation)
        /// </summary>
        /// <returns>Bicycle instance</returns>
        protected override IDeliversFood RegisterVehicle() {
            var bicycle = new Bicycle { 
                Color = "blue",
                Style = "Road",
                Make = "Trek",
                Model = "Foo",
            };
            _logger.LogInfo("Registering a Bicycle to deliver food!", ConsoleColor.Cyan);
            return bicycle;
        }
    }
}
