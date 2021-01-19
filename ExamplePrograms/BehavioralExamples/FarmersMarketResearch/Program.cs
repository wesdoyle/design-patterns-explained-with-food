using System.Collections.Generic;
using BehavioralPatterns.Visitor;
using BehavioralPatterns.Visitor.DataProcessors;
using BehavioralPatterns.Visitor.Visitors;
using RealisticDependencies;

namespace FarmersMarketResearch {
    internal class Program {
        /// <summary>
        /// Here we have an application used to conduct market and sales research at our
        /// local farmer's market. As part of our efforts to improve the services we provide
        /// at the farmer's market, we need to aggregate sales and demographic data already collected
        /// by our vendors.
        /// Each class of vendor has different means of collecting its data, and we want to write
        /// an extensible way to aggregate and report on this data without modifying each class to
        /// write custom research reports.  This would help us write more extensible code (Open/Closed principle)
        /// and keep us from adding unwanted responsibility to the data processing classes
        /// (Single Responsibility principle).
        /// We can leverage the Visitor Pattern, where we make our data processing classes "visitable"
        /// by anything that generates a Report.  Then, we can create individual Visitor classes that
        /// generate their own specific types of reports.
        /// If a processor doesn't provide the data we need for a particular report, we can handle that
        /// logic altogether differently, perhaps notifying the stakeholders that we can't access this data
        /// for reporting purposes.
        /// </summary>
        private static void Main() {
            var logger = new ConsoleLogger();
            var emailer = new Emailer(logger);
            var farmDatabase = new Database(Configuration.ConnectionString, logger);
            var floristDatabase = new Database(Configuration.ConnectionString, logger);
            var bakeryDatabase = new Database(Configuration.ConnectionString, logger);

            logger.LogInfo("🌾 Welcome to the Farmer's Market Research Application!");
            logger.LogInfo("-------------------------------------------------------");

            // Various existing components know how to produce the data we need
            // But we don't want to modify them to add new responsibilities, like
            // generating reports.  We make these Visitable, so that a Visitor
            // can use them as it needs.
            var bakeryDataProcessor = new BakeryDataProcessor(emailer, bakeryDatabase);
            var farmerDataProcessor = new FarmerDataProcessor(farmDatabase);
            var floristDataProcessor = new FloristDataProcessor(emailer, floristDatabase);

            var dataProcessors = new List<IVisitable<Report>> {
                    bakeryDataProcessor, 
                    farmerDataProcessor, 
                    floristDataProcessor
                };

            var reporter = new ReportRunner(logger);
            logger.LogInfo("==== Generating Sales Reports ====");
            reporter.RunReports(dataProcessors, new SaleDataVisitor(logger));

            logger.LogInfo("==== Generating Market Reports ====");
            reporter.RunReports(dataProcessors, new MarketResearchReportVisitor(logger));
        }
    }
}
