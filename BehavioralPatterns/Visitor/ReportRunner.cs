using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Visitor {
    public class ReportRunner {
        // The client code can run visitor operations over any set of elements
        // without figuring out their concrete classes. The accept operation
        // directs a call to the appropriate operation in the visitor object.
        public void RunReports(List<IVisitable<Report>> visitables, IVisitor<Report> visitor) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Running Report on {visitables.Count} Data Providers");
            foreach (var component in visitables) {
                var report = component.Accept(visitor);
                report?.Print();
            }
        }
    }
}
