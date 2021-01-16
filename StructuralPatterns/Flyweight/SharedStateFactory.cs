using System;
using System.Collections.Generic;
using System.Linq;

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
            var hash = string.Join(":", elements);
            Console.WriteLine($"Generated hash: {hash}");
            return hash;
        }

        // Returns an existing NeighborhoodMemberSharedState with a given state or creates a new
        // one and adds it to the tracked flyweights.
        public NeighborhoodMemberSharedState GetFlyweight(NeighborhoodMember sharedState) {
            var key = GetSharedStateHash(sharedState);
            if (!_flyweights.ContainsKey(key)) {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                _flyweights[key] = new NeighborhoodMemberSharedState(sharedState);
            } else {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return _flyweights[key];
        }

        public void DisplayCache() {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"== Shared State Cache:\n{string.Join("\n", _flyweights.Keys)}");
            Console.ResetColor();
        }
    }
}
