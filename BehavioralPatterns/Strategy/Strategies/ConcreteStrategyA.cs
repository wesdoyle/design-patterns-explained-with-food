using System.Collections.Generic;

namespace BehavioralPatterns.Strategy.Strategies {
    public class ConcreteStrategyA : IStrategy {
        public object DoAlgorithm(object data) {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();
            return list;
        }
    }
}
