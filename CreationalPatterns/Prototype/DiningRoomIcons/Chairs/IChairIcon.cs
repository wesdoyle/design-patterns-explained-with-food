namespace CreationalPatterns.Prototype.DiningRoomIcons.Chairs {
    public interface IChairIcon : IDeepCloneable {
        public bool HasSeatCushions { get; }
    }
}
