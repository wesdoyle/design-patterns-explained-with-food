using System;

namespace RealisticDependencies {
    public class Logger : ILogger {
        public void LogInfo(string message) {
            Console.ForegroundColor = ConsoleColor.White;
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

    public interface ILogger {
        public void LogInfo(string message);
        public void LogDebug(string message);
        public void LogError(string message);
    }
}
