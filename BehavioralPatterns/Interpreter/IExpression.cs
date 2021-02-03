namespace BehavioralPatterns.Interpreter {
    public interface IExpression {
        public void Interpret(BarcodeContext context);
    }
}
