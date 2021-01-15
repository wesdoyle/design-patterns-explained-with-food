using CreationalPatterns.Builder;
using System;
using System.Collections.Generic;
using static CreationalPatterns.Builder.Models;

namespace BakeryPurchaseOrderSystem {
    public class Program {
        private static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var orderBuilder = new PurchaseOrderBuilder();

            var breadSupplier = new Supplier("Bulk Food Depot", "orders@example.com", "Doug");

            var orderItems = new List<LineItem> {
                new LineItem("bread flour", 4, 1.2m),
                new LineItem("salt", 2, 0.3m),
                new LineItem("yeast", 8, 0.75m),
            };


            PurchaseOrder breadSuppliesOrder = orderBuilder
                .WithId("b_123")
                .ForCompany("Riverrun Bakery")
                .AtAddress("2828 Main St")
                .FromSupplier(breadSupplier)
                .ForItems(orderItems)
                .RequestDate(DateTime.UtcNow.AddDays(5))
                .BuildPurchaseOrder();

            PrintPurchaseOrder(breadSuppliesOrder);
        }

        private static void PrintPurchaseOrder(PurchaseOrder order) {
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"== 📝 Generated Purchase Order");
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"== ID: {order.Id} | {order.CreatedOn}");
            Console.WriteLine($"== {order.CompanyName}");
            Console.WriteLine($"== {order.CompanyAddress}");
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"== Supplier: {order.Supplier.Name}");
            foreach (var item in order.LineItems) {
                Console.WriteLine($"  - {item.Qty} x {item.Name} @{Math.Round(item.UnitCost, 2)})");
            }
            Console.WriteLine($"== PO Total: $ {Math.Round(order.TotalCost, 2) }");
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"== Requested By: {order.RequestDate})");
            Console.WriteLine($"----------------------------------------");
        }
    }
}
