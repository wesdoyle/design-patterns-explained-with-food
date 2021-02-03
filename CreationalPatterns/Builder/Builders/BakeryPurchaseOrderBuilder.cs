using System;
using System.Collections.Generic;
using static CreationalPatterns.Builder.Models;

namespace CreationalPatterns.Builder.Builders {
    public class BakeryPurchaseOrderBuilder : IBuildsPurchaseOrders {

        private string _id;
        private DateTime _requestDate;
        private string _companyName;
        private string _companyAddress;
        private Supplier _supplier;
        private IEnumerable<LineItem> _lineItems;

        public void SetId() {
            var date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            _id = $"bakery_{date}";
        }

        public void SetRequestDate() {
            _requestDate = DateTime.UtcNow;
        }

        public void SetAddress() {
            _companyAddress = "18 Riverrun Lane";
        }

        public void SetCompany() {
            _companyName = "Riverrun Dry Goods";
        }

        public void SetItems() {
            var orderItems = new List<Models.LineItem> {
                new("bread flour", 4, 1.2m),
                new("salt", 2, 0.3m),
                new("yeast", 8, 0.75m),
            };
            _lineItems = orderItems;
        }

        public void SetSupplier() {
            _supplier = new Supplier {
                Name = "Riverrun Dry Goods",
                ContactName = "Wes",
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
            
            return new PurchaseOrder {
                Id = _id,
                CreatedOn = DateTime.UtcNow,
                CompanyName = _companyName,
                CompanyAddress = _companyAddress,
                LineItems = _lineItems,
                Supplier = _supplier,
                RequestDate = _requestDate
            };
        }

        public static implicit operator PurchaseOrder(BakeryPurchaseOrderBuilder builder) {
            return builder.BuildPurchaseOrder();
        }
    }
}
