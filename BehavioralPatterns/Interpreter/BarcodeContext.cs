using System.Collections.Generic;

namespace BehavioralPatterns.Interpreter {
    public class BarcodeContext {
        public string BarcodeExpression { get; set; }

        public string TranslatedOutput { get { return Origin + TotalQty.ToString(); } }

        public string Origin { get; set; }

        public bool OriginSet = false;

        public int TotalQty = 0;

        public List<char> TerminalExpressionSymbols = new List<char> { 'C', 'M', 'B', '1', '2', '3'  };

        public List<char> NonTerminalExpressionSymbols = new List<char> { };

        public BarcodeContext() { }
    }
}
