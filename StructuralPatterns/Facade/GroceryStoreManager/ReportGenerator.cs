using System;

namespace StructuralPatterns.Facade.GroceryStoreManager {
    public interface IReportGenerator {
        string GenerateReportLog(ReportGenerator.Report report);
    }

    public class ReportGenerator : IReportGenerator {
        public struct Report {
            public string Title;
            public string Description;

        }

        public string GenerateReportLog(Report report) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Generating Report | {report.Title}");
            Console.ResetColor();
            return $"{report.Description}_{DateTime.UtcNow}";
        }
    }
}