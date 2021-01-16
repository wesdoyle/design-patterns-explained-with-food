using System;
using System.Collections.Generic;

namespace StructuralPatterns.Composite {
    /// <summary>
    /// Component Class
    /// A TeaCarton can contain individual cartons of tea as well as sub-cartons of cartons of tea 
    /// This is the base component - it declares common operations for
    /// both simple and complex objects of a composition.
    /// </summary>
    public abstract class TeaCarton {
        /// <summary>
        /// Here we could implement default behavior or strictly delegate the responsibility
        /// to concrete classes.
        /// </summary>
        /// <returns></returns>
        public abstract int GetNumberOfServings();

        public virtual void Add(TeaCarton carton) {
            throw new NotImplementedException("Override in concrete TeaCarton classes");
        }

        public virtual void BuildBundle(Dictionary<TeaCarton, int> order) {
            throw new NotImplementedException("Override in concrete TeaCarton classes");
        }

        public virtual void Remove(TeaCarton carton) {
            throw new NotImplementedException("Override in concrete TeaCarton classes");
        }

        /// <summary>
        /// True if this TeaCarton contains other TeaCartons, False if it is a leaf node. 
        /// </summary>
        /// <returns></returns>
        public virtual bool ContainsSubCarton() {
            return true;
        }
    }
}
