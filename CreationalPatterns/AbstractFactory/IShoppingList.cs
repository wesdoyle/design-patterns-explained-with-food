using System.Collections.Generic;

namespace CreationalPatterns.AbstractFactory {
    public interface IShoppingList {
        public List<string> MakeShoppingList();
    }
}
