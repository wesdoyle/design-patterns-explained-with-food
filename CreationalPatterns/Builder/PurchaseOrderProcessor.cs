using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RealisticDependencies;

namespace CreationalPatterns.Builder {
    /// <summary>
    /// The "Director" class in this Builder Pattern example
    /// </summary>
    public class PurchaseOrderProcessor {
        private readonly IApplicationLogger _logger;
        private readonly IDatabase _database;

        public PurchaseOrderProcessor(IApplicationLogger logger, IDatabase database) {
            _logger = logger;
            _database = database;
        }
        
        public async Task GenerateWeeklyPurchaseOrder(IPurchaseOrderBuilder poBuilder) {
            var po = poBuilder.BuildPurchaseOrder();
            PrintPurchaseOrder(po);
            await SavePurchaseOrderToDatabase(po);
        }

        public async Task SavePurchaseOrderToDatabase(PurchaseOrder purchaseOrder) {
            _logger.LogInfo($"Saving P.O. ({purchaseOrder.Id}) to database");
            await _database.Connect();
            await _database.WriteData(purchaseOrder.Id, JsonConvert.SerializeObject(purchaseOrder));
            await _database.Disconnect();
        }
        
        public void PrintPurchaseOrder(PurchaseOrder order) {
            _logger.LogInfo($"----------------------------------------", ConsoleColor.Blue);
            _logger.LogInfo($"== 📝 Generated Purchase Order", ConsoleColor.Blue);
            _logger.LogInfo($"----------------------------------------", ConsoleColor.Blue);
            _logger.LogInfo($"== ID: {order.Id} | {order.CreatedOn}", ConsoleColor.Blue);
            _logger.LogInfo($"== {order.CompanyName}", ConsoleColor.Blue);
            _logger.LogInfo($"== {order.CompanyAddress}", ConsoleColor.Blue);
            _logger.LogInfo($"----------------------------------------");
            _logger.LogInfo($"== Supplier: {order.Supplier.Name}", ConsoleColor.Blue);
            foreach (var item in order.LineItems) {
                _logger.LogInfo($"  - {item.Qty} x {item.Name} @{Math.Round(item.UnitCost, 2)})", ConsoleColor.DarkBlue);
            }
            _logger.LogInfo($"== PO Total: $ {Math.Round(order.TotalCost, 2) }", ConsoleColor.Blue);
            _logger.LogInfo($"----------------------------------------", ConsoleColor.Blue);
            _logger.LogInfo($"== Deliver By: {order.RequestDate})", ConsoleColor.Blue);
            _logger.LogInfo($"----------------------------------------", ConsoleColor.Blue);
        }
    }
}