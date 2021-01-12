using System.Collections.Generic;

namespace CreationalPatterns.AbstractFactory.Menus {
    public interface IMenu {
        public void PrintDescription();
        public void PrintMenu();
        public List<string> GetMenuIngredients();
    }
}
