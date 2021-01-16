namespace CreationalPatterns.Prototype.DiningRoomIcons {
    public interface IFurnitureIcon : IDeepCloneable {
        public string GetDescription();
        public int GetWeightLbs();
        public string GetColor();
    }
}
