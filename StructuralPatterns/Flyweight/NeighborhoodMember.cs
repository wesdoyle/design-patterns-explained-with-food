namespace StructuralPatterns.Flyweight {
    public class NeighborhoodMember {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public TransportationMethod TransportationMethod { get; set; }
        public Subdivision Subdivision { get; set; }
    }

    public record TransportationMethod {
        public TransportationMethod(string name, int infrastructureCost) {
            Name = name;
            InfrastructureCost = infrastructureCost;
        }
        public string Name { get; set; }
        public int InfrastructureCost { get; set; }
    }

    public record Subdivision {
        public Subdivision(string name, int price) {
            Name = name;
            MedianHousePrice = price;
        }
        public string Name { get; set; }
        public int MedianHousePrice { get; set; }
    }
}
