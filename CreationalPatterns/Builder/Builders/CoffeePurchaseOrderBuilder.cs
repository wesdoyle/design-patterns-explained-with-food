using System;
using System.Collections.Generic;
using static CreationalPatterns.Builder.Models;

namespace CreationalPatterns.Builder.Builders {
    public class CoffeeBuildsPurchaseOrders : IBuildsPurchaseOrders {

        private string _id;
        private DateTime _requestDate;
        private string _companyName;
        private string _companyAddress;
        private Supplier _supplier;
        private IEnumerable<LineItem> _lineItems;

        public void SetId() {
            var date = DateTime.UtcNow.ToString("yy-MMM-dd");
            _id = $"coffee_{date}";
        }

        public void SetRequestDate() {
            _requestDate = DateTime.UtcNow;
        }

        public void SetAddress() {
            _companyAddress = "23 Riverrun Lane";
        }

        public void SetCompany() {
            _companyName = "Riverrun Roasters";
        }

        public void SetItems() {
            var orderItems = new List<Models.LineItem> {
                new("light roast", 3, 30.0m),
                new("dark roast", 3, 30.0m),
            };
            _lineItems = orderItems;
        }

        public void SetSupplier() {
            _supplier = new Supplier {
                Name = "Riverrun Roasters",
                ContactName = "Sam",
                Email = "contact@productivedev.com"
            };
        }

        public PurchaseOrder BuildPurchaseOrder() {
            SetId();
            SetRequestDate();
            SetAddress();
            SetCompany();
            SetItems();
            SetSupplier();
            
            return new() {
                Id = _id,
                CreatedOn = DateTime.UtcNow,
                CompanyName = _companyName,
                CompanyAddress = _companyAddress,
                LineItems = _lineItems,
                Supplier = _supplier,
                RequestDate = _requestDate
            };
        }

        public static implicit operator PurchaseOrder(CoffeeBuildsPurchaseOrders builder) {
            return builder.BuildPurchaseOrder();
        }
    }
}
