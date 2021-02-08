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

    public record Menu (List<MenuItem> MenuItems);

    public record MenuItem(string Name, string Description, decimal Price);        
    
}
