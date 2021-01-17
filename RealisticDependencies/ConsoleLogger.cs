using System;

namespace RealisticDependencies {
    public class ConsoleLogger : IApplicationLogger {
        public ConsoleLogger() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void LogInfo(string message, ConsoleColor color = ConsoleColor.White) {
            Console.ForegroundColor = color;
            Write(message);
        }

        public void LogDebug(string message) {
            Console.ForegroundColor = ConsoleColor.Blue;
            Write(message);
        }

        public void LogError(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Write(message);
        }

        private static void Write(string message) {
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    public interface IApplicationLogger {
        public void LogInfo(string message, ConsoleColor color = ConsoleColor.White);
        public void LogDebug(string message);
        public void LogError(string message);
    }
}
