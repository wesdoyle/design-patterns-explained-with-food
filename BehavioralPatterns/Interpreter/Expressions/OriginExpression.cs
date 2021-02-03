using System.Collections.Generic;

namespace BehavioralPatterns.Interpreter.Expressions {
    public class OriginExpression : IExpression {
        private readonly List<char> _origins = new List<char> { 'C', 'M', 'B' };
        public void Interpret(BarcodeContext context) {
            if (context.OriginSet == true) return;
            foreach (var character in context.BarcodeExpression) {
                if (_origins.Contains(character)) {
                    switch (character) {
                        case 'C':
                            context.Origin = "🇨🇴 Colombia ";
                            break;
                        case 'M':
                            context.Origin = "🇲🇽 Mexico ";
                            break;
                        case 'B':
                            context.Origin = "🇧🇪 Belgium ";
                            break;
                    }
                    context.OriginSet = true;
                    return;
                }
            }
        }
    }
}
