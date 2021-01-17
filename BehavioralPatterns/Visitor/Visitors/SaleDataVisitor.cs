using BehavioralPatterns.Visitor.Components;

namespace BehavioralPatterns.Visitor.Visitors {
    public class SaleDataVisitor : IVisitor {
        public void Visit(FloristOrderProcessor order) {
            throw new System.NotImplementedException();
        }

        public void Visit(BakeryOrderProcessor orderProcessor) {
            throw new System.NotImplementedException();
        }

        public void Visit(VegetableOrderProcessor orderProcessor) {
            throw new System.NotImplementedException();
        }
    }
}
