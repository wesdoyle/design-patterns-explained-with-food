namespace StructuralPatterns.Composite.IndividualCartons {
    public class WhiteTeaCarton : TeaCarton {
        public override int GetNumberOfServings() => 60;
        public override bool ContainsSubCarton() => false;
    }
}
