namespace CreationalPatterns.Prototype.DiningRoomIcons.Tables {
    public interface ITableIcon : IDeepCloneable {
        public string GetTableTopShape();
        public int GetTableNumberOfLegs();
    }
}
