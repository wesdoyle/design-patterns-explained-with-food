namespace CreationalPatterns.Builder {
    public interface IBuildsPurchaseOrders {
        void SetId();
        void SetCompany();
        void SetAddress();
        void SetRequestDate();
        void SetSupplier();
        void SetItems();
        PurchaseOrder BuildPurchaseOrder();
    }

}
