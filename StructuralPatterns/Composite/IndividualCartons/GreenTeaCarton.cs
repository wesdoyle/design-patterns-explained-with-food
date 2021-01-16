namespace StructuralPatterns.Composite.IndividualCartons {
    public class GreenTeaCarton : TeaCarton {
        public override int GetNumberOfServings() => 24;
        public override bool ContainsSubCarton() => false;
    }
}
