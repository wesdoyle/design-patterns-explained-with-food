namespace CreationalPatterns.Prototype.DiningRoomIcons.Tables {
    public class CafeTableIcon : ITableIcon {
        public int GetTableNumberOfLegs() => 3;

        public string GetTableTopShape() => "round";

        public IDeepCloneable DeepClone() {
            return this.CloneJson();
        }
    }
}
