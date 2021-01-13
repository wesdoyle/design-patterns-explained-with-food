namespace CreationalPatterns.Prototype.DiningRoomIcons.Chairs {
    public class BarStoolIcon : IChairIcon {
        public bool HasSeatCushions => true;

        public IDeepCloneable DeepClone() {
            return this.CloneJson();
        }
    }
}
