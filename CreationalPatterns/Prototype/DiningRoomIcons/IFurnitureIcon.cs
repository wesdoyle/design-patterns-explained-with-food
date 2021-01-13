namespace CreationalPatterns.Prototype.DiningRoomFurniture {
    public interface IFurnitureIcon : IDeepCloneable {
        public string GetDescription();
        public int GetWeightLbs();
        public string GetColor();
    }
}
