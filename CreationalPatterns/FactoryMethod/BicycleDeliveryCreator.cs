using CreationalPatterns.FactoryMethod.VehicleTypes;
using RealisticDependencies;
using System;

namespace CreationalPatterns.FactoryMethod {
    public class BicycleDeliveryCreator : DeliveryCreator {
        public BicycleDeliveryCreator(IAmqpQueue deliveryQueue) : base(deliveryQueue) { }
        protected override IDeliversFood RegisterVehicle() {
            var bicycle = new Bicycle { 
                Color = "blue",
                Style = "Road",
                Make = "Trek",
                Model = "Foo",
            };
            Console.WriteLine("Registering a Bicycle to deliver food!");
            return bicycle;
        }
    }
}
