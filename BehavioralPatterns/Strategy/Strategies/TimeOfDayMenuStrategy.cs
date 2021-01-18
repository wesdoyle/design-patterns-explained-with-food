using RealisticDependencies;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BehavioralPatterns.Strategy.Strategies {
    /// <summary>
    /// Here we have a menu-building strategy that accounts for
    /// the time of day - we return a menu items containing only
    /// items specific to breakfast, lunch, or dinner, depending on
    /// the time reported by our IDateTimeProvider
    /// </summary>
    public class TimeOfDayMenuStrategy : IMenuGenerationStrategy {
        private readonly IDatabase _menuDatabase;
        private readonly IDateTimeProvider _date;
        private List<MenuItem> _allMenuItems;

        public TimeOfDayMenuStrategy(IDatabase menuDatabase, IDateTimeProvider date) {
            _date = date;
            _menuDatabase = menuDatabase;
        }

        /// <summary>
        /// The method required by the interace to implement this strategy
        /// </summary>
        /// <returns></returns>
        public async Task<Menu> GenerateMenu() {
            var serializedMenuItems = await _menuDatabase.DumpData();
            
            _allMenuItems = serializedMenuItems 
                .Select(item => JsonConvert.DeserializeObject<MenuItem>(item))
                .ToList();
            
            var isBreakfastTime = _date.IsMorning();
            var isLunchTime = _date.IsAfternoon();
            
            if (isBreakfastTime) { return GenerateBreakfastMenu(); }
            if (isLunchTime) { return GenerateLunchMenu(); }
            return GenerateDinnerMenu();
        }

        private Menu GenerateDinnerMenu() {
            var options = new List<string> {"curry rice", "wild rice soup"};
            var dinnerItems = _allMenuItems.Where(item => options.Contains(item.Name)).ToList();
            return new Menu(dinnerItems);
        }

        private Menu GenerateLunchMenu() {
            var options = new List<string> {"black bean burrito", "chips and salsa"};
            var lunchItems = new List<MenuItem>();
            return new Menu(lunchItems);
        }

        private Menu GenerateBreakfastMenu() {
            var options = new List<string> {"scrambled eggs", "french toast", "bagel with lox"};
            var breakfastItems = new List<MenuItem>();
            return new Menu(breakfastItems);
        }
    }
}
