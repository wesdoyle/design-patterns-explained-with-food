using System;

namespace BehavioralPatterns.TemplateMethod {
    public class ConcreteClass2 : AbstractClass {
        protected override void RequiredOperations1() {
            throw new NotImplementedException();
        }

        protected override void RequiredOperation2() {
            throw new NotImplementedException();
        }

        protected override void Hook1() {
            throw new NotImplementedException();
        }
    }
}
