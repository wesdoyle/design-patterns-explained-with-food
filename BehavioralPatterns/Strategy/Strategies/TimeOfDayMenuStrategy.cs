using RealisticDependencies;
using System;

namespace BehavioralPatterns.Strategy.Strategies {
    public class TimeOfDayMenuStrategy : IMenuGenerationStrategy {
        private readonly IDateTimeProvider _date;
        private readonly DateTime _currentTime;

        public TimeOfDayMenuStrategy(IDateTimeProvider date) {
            _date = date;
            _currentTime = _date.GetCurrentTimeUtc();
        }

        Menu IMenuGenerationStrategy.GenerateMenu() {
            if (_currentTime.Hour > 6 && _currentTime.Hour < 12) {
                return GenerateBreakfastMenu();
            } else if (_currentTime.Hour > 12 && _currentTime.Hour < 16) {
                return GenerateLunchMenu();
            } else {
                return GenerateDinnerMenu();
            }
        }

        private Menu GenerateDinnerMenu() {
            return new Menu {

            };
        }

        private Menu GenerateLunchMenu() {
            return new Menu {

            };
        }

        private Menu GenerateBreakfastMenu() {
            return new Menu {

            };
        }
    }
}
