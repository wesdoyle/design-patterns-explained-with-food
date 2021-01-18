using System.Collections.Generic;

namespace BehavioralPatterns.Strategy {
    public interface IMenuGenerationStrategy {
        Menu GenerateMenu();
    }

    public record Menu {
        public List<MenuItem> MenuItems { get; set; }
    }

    public record MenuItem {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
