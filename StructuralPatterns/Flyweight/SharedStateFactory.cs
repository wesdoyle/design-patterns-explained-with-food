using System;
using System.Collections.Generic;

namespace StructuralPatterns.Flyweight {
    public class SharedStateFactory {
        private readonly Dictionary<string, NeighborhoodMemberSharedState> _flyweights = new();

        public SharedStateFactory(params NeighborhoodMember[] members) {
            Console.WriteLine("Initializing Shared State (Flyweight) Factory");
            foreach (var member in members) {
                _flyweights[GetSharedStateHash(member)] = new NeighborhoodMemberSharedState(member);
            }
        }
        // Returns a NeighborhoodMemberSharedState's string hash for a given state.
        private static string GetSharedStateHash(NeighborhoodMember key) {
            var elements = new List<object> {
                key.Subdivision, 
                key.TransportationMethod, 
            };
            return string.Join(":", elements);
        }

        // Returns an existing NeighborhoodMemberSharedState with a given state or creates a new
        // one and adds it to the tracked flyweights.
        public NeighborhoodMemberSharedState GetFlyweight(NeighborhoodMember sharedState) {
            var key = GetSharedStateHash(sharedState);
            if (_flyweights.ContainsKey(key)) {
                return _flyweights[key];
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
            Console.ResetColor();
            _flyweights[key] = new NeighborhoodMemberSharedState(sharedState);
            return _flyweights[key];
        }

        public void DisplayCache() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"== Shared State Cache:\n{string.Join("\n", _flyweights.Keys)}");
            Console.ResetColor();
        }
    }
}
