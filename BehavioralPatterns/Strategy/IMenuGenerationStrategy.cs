using System.Collections.Generic;

namespace BehavioralPatterns.Strategy {
    /// <summary>
    /// A strategy for generating a menu.  Classes that implement this behavior
    /// must produce an instance of a Menu object.
    /// </summary>
    public interface IMenuGenerationStrategy {
        Menu GenerateMenu();
    }

    public record Menu {
        public Menu(List<MenuItem> menuItems) => MenuItems = menuItems;
        public List<MenuItem> MenuItems { get; set; }
    }

    public record MenuItem {
        public MenuItem(string name, string description, decimal price)
            => (Name, Description, Price) = (name, description, price);
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
