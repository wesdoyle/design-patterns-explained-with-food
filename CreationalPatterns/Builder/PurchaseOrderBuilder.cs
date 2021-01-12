using System;
using System.Collections.Generic;
using static CreationalPatterns.Builder.Models;

namespace CreationalPatterns.Builder {
    public class PurchaseOrderBuilder : IPurchaseOrderBuilder {

        private string _id;
        private DateTime _requestDate;
        private string _companyName;
        private string _companyAddress;
        private Supplier _supplier;
        private IEnumerable<LineItem> _lineItems;

        public IPurchaseOrderBuilder WithId(string id) {
            _id = id;
            return this;
        }

        public IPurchaseOrderBuilder RequestDate(DateTime date) {
            _requestDate = date;
            return this;
        }

        public IPurchaseOrderBuilder AtAddress(string address) {
            _companyAddress = address;
            return this;
        }

        public IPurchaseOrderBuilder ForCompany(string companyName) {
            _companyName = companyName;
            return this;
        }

        public IPurchaseOrderBuilder ForItems(List<LineItem> lineItems) {
            _lineItems = lineItems;
            return this;
        }

        public IPurchaseOrderBuilder FromSupplier(Supplier supplier) {
            _supplier = supplier;
            return this;
        }

        public PurchaseOrder BuildPurchaseOrder() {
            return new PurchaseOrder() {
                Id = _id,
                CreatedOn = DateTime.UtcNow,
                CompanyName = _companyName,
                CompanyAddress = _companyAddress,
                LineItems = _lineItems,
                Supplier = _supplier,
                RequestDate = _requestDate
            };
        }

        public static implicit operator PurchaseOrder(PurchaseOrderBuilder builder) {
            return builder.BuildPurchaseOrder();
        }
    }
}
