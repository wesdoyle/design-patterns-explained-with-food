using System;
using System.Collections.Generic;
using RealisticDependencies;

namespace BehavioralPatterns.Visitor {
    public class ReportRunner {
        private readonly IApplicationLogger _logger;

        public ReportRunner(IApplicationLogger logger) {
            _logger = logger;
        }
        
        // The client code can run visitor operations over any set of elements
        // without figuring out their concrete classes. The accept operation
        // directs a call to the appropriate operation in the visitor object.
        public void RunReports(List<IVisitable<Report>> visitables, IVisitor<Report> visitor) {
            _logger.LogInfo($"Running Report on {visitables.Count} Data Providers", ConsoleColor.Cyan);
            foreach (var component in visitables) {
                var report = component.Accept(visitor);
                report?.Print();
            }
        }
    }
}
