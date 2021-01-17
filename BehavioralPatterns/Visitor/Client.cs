using System.Collections.Generic;

namespace BehavioralPatterns.Visitor {
    public class Client {
        // The client code can run visitor operations over any set of elements
        // without figuring out their concrete classes. The accept operation
        // directs a call to the appropriate operation in the visitor object.
        public static void ClientCode(List<IVisitable> components, IVisitor visitor) {
            foreach (var component in components) {
                component.Accept(visitor);
            }
        }
    }
}
