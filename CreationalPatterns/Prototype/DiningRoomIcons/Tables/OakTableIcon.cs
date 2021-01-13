namespace CreationalPatterns.Prototype.DiningRoomIcons.Tables {
    public class OakTableIcon : ITableIcon {
        public OakTableIcon() { }

        public int GetTableNumberOfLegs() => 4;

        public string GetTableTopShape() => "rectangle";

        public IDeepCloneable DeepClone() {
            return this.CloneJson();
        }
    }
}
