using System;

namespace BehavioralPatterns.Interpreter.Expressions {
    public class QuantityExpression : IExpression {
        private readonly char _inputChar;

        public QuantityExpression(char inputChar) {
            _inputChar = inputChar;
        }

        public void Evaluate(BarcodeContext context) {
            if (int.TryParse(_inputChar.ToString(), out var _)) {
                context.TotalQty += 1;
            }
        }
    }
}
