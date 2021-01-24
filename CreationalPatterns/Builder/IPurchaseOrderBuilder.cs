namespace CreationalPatterns.Builder {
    public interface IPurchaseOrderBuilder {
        void SetId();
        void SetCompany();
        void SetAddress();
        void SetRequestDate();
        void SetSupplier();
        void SetItems();
        PurchaseOrder BuildPurchaseOrder();
    }

}
