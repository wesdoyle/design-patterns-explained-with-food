using System.Collections.Generic;
using System.Threading.Tasks;

namespace BehavioralPatterns.Strategy {
    /// <summary>
    /// A strategy for generating a menu.  Classes that implement this behavior
    /// must produce an instance of a Menu object.
    /// </summary>
    public interface IMenuGenerationStrategy {
        Task<Menu> GenerateMenu();
    }

    public record Menu {
        public Menu(List<MenuItem> menuItems) => MenuItems = menuItems;
        public List<MenuItem> MenuItems { get; }
    }

    public record MenuItem {
        public MenuItem(string name, string description, decimal price)
            => (Name, Description, Price) = (name, description, price);
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
    }
}
