using System;
using System.Collections.Generic;
using static CreationalPatterns.Builder.Models;

namespace CreationalPatterns.Builder {
    public interface IPurchaseOrderBuilder {
        IPurchaseOrderBuilder WithId(string id);
        IPurchaseOrderBuilder ForCompany(string companyName);
        IPurchaseOrderBuilder AtAddress(string address);
        IPurchaseOrderBuilder RequestDate(DateTime date);
        IPurchaseOrderBuilder FromSupplier(Supplier supplier);
        IPurchaseOrderBuilder ForItems(List<LineItem> lineItems);
        PurchaseOrder BuildPurchaseOrder();
    }

}
