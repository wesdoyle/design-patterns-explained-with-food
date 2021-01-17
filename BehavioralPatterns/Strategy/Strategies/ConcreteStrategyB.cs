using System.Collections.Generic;

namespace BehavioralPatterns.Strategy.Strategies {
    public class ConcreteStrategyB : IStrategy {
        public object DoAlgorithm(object data) {
            var list = data as List<string>;
            list.Sort();
            return list;
        }
    }
}
