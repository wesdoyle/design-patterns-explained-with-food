using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BehavioralPatterns.Iterator.Iterators;

namespace BehavioralPatterns.Iterator.Aggregates {
    public class RestaurantCollection : Aggregate {
        private List<Restaurant> _restaurants = new();
        private bool _isPopularitySorted;
        private bool _isRatingSorted;

        public override IEnumerator GetEnumerator() {
            return new RestaurantIterator(this);
        }

        public List<Restaurant> GetAll() => _restaurants;

        public void AddItem(Restaurant restaurant) {
            _restaurants.Add(restaurant);
            if (_isPopularitySorted) {
                SortByPopularityDescending();
            }
            if (_isRatingSorted) {
                SortByRatingDescending();
            }
        }

        public void SortByPopularityDescending() {
            _isPopularitySorted = true;
            _restaurants = _restaurants.OrderByDescending(rest => rest.VisitCount).ToList();
        }

        public void SortByRatingDescending() {
            _isRatingSorted = true;
            _restaurants = _restaurants.OrderByDescending(rest => rest.Rating).ToList();
        }
    }
    
    public record Restaurant {
        public Restaurant(string name, int rating, int visitCount) {
            Name = name;
            Rating = rating;
            VisitCount = visitCount;
        }

        public string Name { get; set; }
        public int Rating { get; set; }
        public int VisitCount { get; set; }
    }
}
