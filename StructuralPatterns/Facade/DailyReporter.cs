using RealisticDependencies;
using StructuralPatterns.Facade.GroceryStoreManager;

namespace StructuralPatterns.Facade {
    /// <summary>
    /// Facade Example
    /// Though we're not using dependency injection here to simplify the example,
    /// The DailyReporter provides a Facade over the complex interactions required
    /// to work with the GroceryStoreManager functionality.
    /// Clients of the DailyReporter have a very simple interface to complete
    /// more complex business logic hidden by the facade.
    /// </summary>
    public class DailyReporter {
        private readonly IFinanceCalculator _finance;
        private readonly IInventoryManager _inventory;
        private readonly IReportGenerator _report;
        private readonly IVendorNotifier _vendors;

        private readonly ISendsEmails _emailer = new Emailer(new ConsoleLogger());
        private readonly IDatabase _database = new Database(Configuration.ConnectionString, new ConsoleLogger());
        private readonly IAmqpQueue _queue = new CloudQueue(new ConsoleLogger());
        private readonly IRecipesApi _api = new RecipesApi(new ConsoleLogger());
        private readonly IApplicationLogger _logger = new ConsoleLogger();

        public DailyReporter() {
            _finance = new FinanceCalculator();
            _inventory = new InventoryManager(_emailer, _queue, _database, _api);
            _report =  new ReportGenerator();
            _vendors = new VendorNotifier(_database, _emailer);
            _logger = new ConsoleLogger();
        }

        public void KickOffProduceReport() {
            _finance.CalculateMonthTotalRevenue();
            _inventory.ProcessCurrentInventoryReport();

            var vendors = _vendors.GetVendorsForDepartment("produce");

            foreach (var vendor in vendors) {
                _vendors.NotifyVendorOfCurrentStock(vendor);
                _finance.CalculateMonthTotalRevenueForVendor(vendor);
            }

            var report = new ReportGenerator.Report {
                Title = "Daily Produce Report",
                Description = "The daily produce report details..."
            };

            var reportLog = _report.GenerateReportLog(report);

            _logger.LogInfo(reportLog);
        }
    }
}
