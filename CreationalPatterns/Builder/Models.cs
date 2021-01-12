namespace CreationalPatterns.Builder {
    public class Models {
        public struct LineItem {
            public string Name { get; set; }
            public int Qty { get; set; }
            public decimal UnitCost { get; set; }
            public LineItem(string name, int qty, decimal unitCost)
                => (Name, Qty, UnitCost) = (name, qty, unitCost);
        }

        public struct Supplier {
            public string Name { get; set; }
            public string Email { get; set; }
            public string ContactName { get; set; }
            public Supplier(string name, string email, string contactName)
                => (Name, Email, ContactName) = (name, email, contactName);
        }
    }
}
