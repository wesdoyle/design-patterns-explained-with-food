using BehavioralPatterns.Visitor.DataProcessors;

// The Visitor Pattern has nothing to do with visitation.
// Rather, it’s a way to design hierarchies so that new virtual-acting functions
// can be added without changing the hierarchies.
// - Scott Meyers https://www.artima.com/cppsource/top_cpp_aha_moments.html

namespace BehavioralPatterns.Visitor {
    public interface IVisitor<out T> where T: class {
        public T Visit(FloristDataProcessor processor);
        public T Visit(BakeryDataProcessor orderProcessor);
        public T Visit(FarmerDataProcessor orderProcessor);
    }
}
