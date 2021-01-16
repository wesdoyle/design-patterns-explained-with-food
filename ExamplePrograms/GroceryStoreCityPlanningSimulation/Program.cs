using System;
using System.Collections.Generic;
using StructuralPatterns.Flyweight;

namespace GroceryStoreCityPlanningSimulation {
    internal class Program {
        /// <summary>
        /// Here we have a mock program that might be used as part of a simulation that is
        /// used to generate data to help choose the optimal location for a new grocery store
        /// co-op in a neighborhood of people who travel by foot and bicycle.
        /// The flyweight pattern is used to save RAM when creating the very large number
        /// of objects used to represent individual NeighborhoodMembers by separating out
        /// intrinsic state from extrinsic state and sharing state where it makes sense. 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("🚴 Starting City Planning Simulation for new Grocery Store Location");
            Console.WriteLine("--------------------------------------------------------------------");

            var rng = new Random();
            const int simulationPopulationSize = 10;
            const int simulationHeightWidth = 100;
            const int flyweightBankSize = 3;

            var transportModes = new[] {
                new TransportationMethod("walk", 1), 
                new TransportationMethod("bicycle", 2)
            };

            var subdivisions = new[] {
                new Subdivision("north_side", 120), 
                new Subdivision("east_side", 210), 
                new Subdivision("downtown", 300), 
                new Subdivision("lakeside", 310)
            };

            var neighborhoodMembers = new NeighborhoodMember[flyweightBankSize];

            for (var i = 0; i < flyweightBankSize; i++) {
                var member = new NeighborhoodMember();
                var (x, y) = GetRandomCoordinates(rng, simulationHeightWidth);
                var modeOfTransport = GetRandomTransportation(rng, transportModes);
                var subdivision = GetRandomSubdivision(rng, subdivisions);
                member.PositionX = x;
                member.PositionY = y;
                member.TransportationMethod = modeOfTransport;
                member.Subdivision = subdivision;
                neighborhoodMembers[i] = member;
            }

            var factory = new SharedStateFactory(neighborhoodMembers);
            factory.DisplayCache();

            for (var i = 0; i < simulationPopulationSize; i++) {
                var member = new NeighborhoodMember();
                var (item1, item2) = GetRandomCoordinates(rng, simulationHeightWidth);
                var modeOfTransport = GetRandomTransportation(rng, transportModes);
                var subdivision = GetRandomSubdivision(rng, subdivisions);
                member.PositionX = item1;
                member.PositionY = item2;
                member.TransportationMethod = modeOfTransport;
                member.Subdivision = subdivision;
                AddMemberToSimulation(factory, member);
            }

            Console.WriteLine("Simulation Complete.");
            Console.WriteLine("--------------------------------------------------------------------");
        }

        private static void AddMemberToSimulation(SharedStateFactory factory, NeighborhoodMember member) {

            var flyweight = factory.GetFlyweight(new NeighborhoodMember {
                TransportationMethod = member.TransportationMethod,
                Subdivision = member.Subdivision
            });

            // Here, our simulation client calculates extrinsic state and passes it to the flyweight's methods
            flyweight.RenderPosition(member);
        }

        private static Subdivision GetRandomSubdivision(Random rng, IReadOnlyList<Subdivision> subdivisions) {
            var randomIndex = rng.Next(subdivisions.Count);
            return subdivisions[randomIndex];
        }
        
        private static TransportationMethod GetRandomTransportation(Random rng, IReadOnlyList<TransportationMethod> transportMethods) {
            var randomIndex = rng.Next(transportMethods.Count);
            return transportMethods[randomIndex];
        }

        private static Tuple<int, int> GetRandomCoordinates(Random rng, int limit) {
            return new(rng.Next(0, limit), rng.Next(0, limit));
        }
    }
}
