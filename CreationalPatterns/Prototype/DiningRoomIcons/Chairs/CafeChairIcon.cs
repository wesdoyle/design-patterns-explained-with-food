namespace CreationalPatterns.Prototype.DiningRoomIcons.Chairs {
    public class CafeChairIcon : IChairIcon {
        public bool HasSeatCushions => false;

        public IDeepCloneable DeepClone() {
            CafeChairIcon cafeChairIcon = null;
            return cafeChairIcon.DeepClone();
        }
    }
}
