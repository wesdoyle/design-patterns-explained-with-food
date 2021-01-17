using System;

namespace BestRestaurantFinder {
    internal class Program {
        /// <summary>
        /// We would like to travel to find the best restaurants one-by-one in our city from our
        /// current location.  We want to visit the "best" restaurants first, and the "worst" last.
        /// "Best" is subjective, however, so we have more than one way to traverse our network.
        /// Since we have to follow a complex data structure representing the traversal
        /// path in different ways, we'll use the Iterator Pattern to establish different means of
        /// traversing our aggregate object without exposing its internal representation.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
    }
}
