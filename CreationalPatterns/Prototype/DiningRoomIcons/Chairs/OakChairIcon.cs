namespace CreationalPatterns.Prototype.DiningRoomIcons.Chairs {
    public class OakChairIcon : IChairIcon {
        public bool HasSeatCushions => false;

        public IDeepCloneable DeepClone() {
            return this.CloneJson();
        }
    }
}
