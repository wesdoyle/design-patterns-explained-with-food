using RealisticDependencies;
using System;
using BehavioralPatterns.Iterator.Aggregates;

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
        private static void Main() {
            var logger = new ConsoleLogger();
            logger.LogInfo("🚗 Welcome to the Restaurant Finder");
            logger.LogInfo("------------------------------------");
            logger.LogInfo("Enter a number of restaurants to iterate over:");

            string userInput;
            bool isNumber;
            int totalNumber;

            while (true) {
                userInput = Console.ReadLine();
                isNumber = int.TryParse(userInput, out totalNumber);
                if (!isNumber) {
                    logger.LogInfo("Please enter a valid number between 1 and 10_000.");
                    continue;
                } else if (totalNumber > 10_000) {
                    logger.LogInfo("That's a bit too much. Try something less thatn 10_000.");
                    continue;
                } else {
                    break;
                }
            }

            bool isVisitSort = false;
            bool isRatingSort = false;

            while (true) {
                logger.LogInfo("Do you want to iterate by Visit Popularity or Rating? (v/r)");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "v") {
                    isVisitSort = true;
                    break;
                } else if (userInput == "r") {
                    isRatingSort = true;
                    break;
                } else {
                    logger.LogInfo("Please enter [v] for Visit Sort or [r] for Rating Sort.");
                    continue;
                }
            }

            var rng = new Random();
            var collection = new RestaurantCollection();

            for (var i = 0; i < totalNumber; i++) {
                var name = Guid.NewGuid().ToString().Substring(0, 12);
                var rating = rng.Next(0, 100);
                var visitCount = rng.Next(0, 5_000);
                collection.AddItem(new(name, rating, visitCount));
            }

            if (isRatingSort) {
                logger.LogInfo("Sorting by Rating");
                collection.SortByRatingDescending();
            }

            if (isVisitSort) {
                logger.LogInfo("Sorting by Visit Count");
                collection.SortByPopularityDescending();
            }

            foreach (var element in collection) {
                var restaurant = (Restaurant)element;
                logger.LogInfo($"Rating: {restaurant.Rating}; Visits: {restaurant.VisitCount}");
            }
        }
    }
}
