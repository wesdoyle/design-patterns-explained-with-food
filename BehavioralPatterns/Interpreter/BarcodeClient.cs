using BehavioralPatterns.Interpreter.Expressions;
using RealisticDependencies;
using System;
using System.Collections.Generic;

namespace BehavioralPatterns.Interpreter {
    public class BarcodeClient {
        private readonly IApplicationLogger _logger;
        private readonly BarcodeContext _context;

        public BarcodeClient(IApplicationLogger logger, BarcodeContext context) {
            _logger = logger;
            _context = context;
        }

        public void TranslateBarcode() {
            _logger.LogInfo($"Translating scanned barcode: {_context.BarcodeExpression}", ConsoleColor.Green);
            var chars = _context.BarcodeExpression.ToCharArray();
            var expressions = new List<IExpression>();

            // This is usually represented as an Abstract Syntax Tree.
            // For the purposes of this example, we have a simple grammar
            // and sentences are represented as lists (i.e. only terminal nodes).
            foreach (var symbol in chars) {
                _logger.LogInfo($"Interpreting symbol: {symbol}", ConsoleColor.DarkGray);

                // If our symbol matches Terminal Expression Symbols, add it to our Expressions
                if (_context.TerminalExpressionSymbols.Contains(symbol)) {

                    // If it's a number, create a quantity expression
                    if (int.TryParse(symbol.ToString(), out int _)) {
                        expressions.Add(new QuantityExpression(symbol));
                    }

                    // Otherwise, create an origin expression
                    expressions.Add(new OriginExpression());
                }
            }

            foreach (var expression in expressions) {
                expression.Evaluate(_context);
            }

            var output = _context.TranslatedOutput;

            if (!string.IsNullOrWhiteSpace(output)) {
                _logger.LogInfo($"This translates to: {_context.TranslatedOutput}", ConsoleColor.Green);
            } else {
                _logger.LogInfo($"Hmm... That looks like an invalid barcode.", ConsoleColor.Red);
            }
        }
    }
}
