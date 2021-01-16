using System;
using System.Threading.Tasks;

namespace RealisticDependencies {
    public interface IDatabase {
        Task Connect();
        Task Disconnect();
    }

    public class Database : IDatabase
    {
        private readonly string _connectionString;

        public Database(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task Connect() {
            await Task.Delay(2500);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Connected to Database.");
            Console.ResetColor();
        }

        public async Task Disconnect() {
            await Task.Delay(2500);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Disconnected from Database.");
            Console.ResetColor();
        }
    }
}
