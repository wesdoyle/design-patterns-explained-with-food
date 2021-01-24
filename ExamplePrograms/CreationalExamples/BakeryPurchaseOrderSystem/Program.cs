using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreationalPatterns.Builder;
using CreationalPatterns.Builder.Builders;
using RealisticDependencies;

namespace BakeryPurchaseOrderSystem {
    /// <summary>
    /// Here we have a PO Builder that we use to generate purchase orders for our bakery.
    /// Creating a new instance of a Purchase Order can be a confusing and lengthy process.
    /// To improve the experience of instantiating new Purchase Order objects, and to make
    /// the semantics more clear, we make use of the Builder Pattern.
    /// One of the design benefits of the Builder Pattern is that the algorithms for constructing
    /// an object are independent of the parts that make up the object and how they're assembled.
    /// We can demonstrate two types of builder pattern approaches:
    /// - Builder + Director collaboration,
    ///     where depending on the concrete type of Builder provided to the Director, a different PO will be generated.
    ///     We can encapsulate the building of a PO for particular vendors in their own Builder Types.
    /// - Fluent Builder pattern,
    ///     We allow the creation of custom Purchase orders using a fluent syntax to set custom properties on 
    ///     instances of the same PurchaseOrder type. In C#, we can also make it very easy to cast our Builder
    ///     (where the construction logic is defined) into the Type of object it builds using an implicit operator.
    /// </summary>
    internal class Program {
        private async static Task Main() {

            // First Approach - Typical GoF Builder Pattern (Director <- Builder)
            var logger = new ConsoleLogger();
            var database = new Database(Configuration.ConnectionString, logger);
            
            // Concrete Builders
            var bakeryPoBuilder = new BakeryBuildsPurchaseOrders();
            var coffeePoBuilder = new CoffeeBuildsPurchaseOrders();

            // Director 
            var poProcessor = new PurchaseOrderProcessor(logger, database);
            
            await poProcessor.GenerateWeeklyPurchaseOrder(bakeryPoBuilder);
            await poProcessor.GenerateWeeklyPurchaseOrder(coffeePoBuilder);
            
            
            // Second Approach - "Custom" builder using a fluent syntax
            var customOrder = new FluentPurchaseOrderBuilder();

            var items = new List<Models.LineItem> {
                new("cups", 100, 1.0m),
                new("napkins", 250, 0.3m),
            };

            var supplier = new Models.Supplier("Jenkins", "contact@productivedev.com", "C.I. Jenkins");
            
            customOrder
                .WithId("Custom_Order")
                .AtAddress("123 Riverrun Lane")
                .ForCompany("Productive Dev")
                .FromSupplier(supplier)
                .RequestDate(DateTime.UtcNow.AddDays(2))
                .ForItems(items);

            await poProcessor.SavePurchaseOrderToDatabase(customOrder);
            poProcessor.PrintPurchaseOrder(customOrder);
        }

    }
}
