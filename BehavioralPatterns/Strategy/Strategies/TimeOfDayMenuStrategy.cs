using RealisticDependencies;
using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Strategy.Strategies {
    public class TimeOfDayMenuStrategy : IMenuGenerationStrategy {
        private readonly IDatabase _menuDatabase;
        private readonly IDateTimeProvider _date;

        public TimeOfDayMenuStrategy(IDatabase menuDatabase, IDateTimeProvider date) {
            _menuDatabase = menuDatabase;
            _date = date;
        }

        public Menu GenerateMenu() {
            var isBreakfastTime = _date.IsMorning();
            var isLunchTime = _date.IsAfternoon();

            if (isBreakfastTime) { return GenerateBreakfastMenu(); } 
            else if (isLunchTime) { return GenerateLunchMenu(); } 
            else { return GenerateDinnerMenu(); }
        }

        private static Menu GenerateDinnerMenu() {
            var dinnerItems = new List<MenuItem>();
            return new Menu(dinnerItems);
        }

        private static Menu GenerateLunchMenu() {
            var lunchItems = new List<MenuItem>();
            return new Menu(lunchItems);
        }

        private static Menu GenerateBreakfastMenu() {
            var breakfastItems = new List<MenuItem>();
            return new Menu(breakfastItems);
        }
    }
}
