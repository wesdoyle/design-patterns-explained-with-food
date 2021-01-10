using CreationalPatterns.FactoryMethod.VehicleTypes;
using RealisticDependencies;
using System;

namespace CreationalPatterns.FactoryMethod {
    public class CarDeliveryCreator : DeliveryCreator {
        public CarDeliveryCreator(IAmqpQueue deliveryQueue) : base(deliveryQueue) { }
        protected override IDeliversFood RegisterVehicle() {
            var car = new Car { 
                Year = 2010,
                Color = "black",
                Make = "Honda",
                Model = "Civic",
                LicensePlate = "123",
            };
            Console.WriteLine("Registering a Car to deliver food!");
            return car;
        }
    }
}
