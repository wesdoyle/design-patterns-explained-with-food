using System;
using System.Threading.Tasks;

namespace RealisticDependencies {
    public class Database {
        private readonly string _connectionString;
        public Database(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task Connect() {
            await Task.Delay(2500);
            Console.WriteLine("Connected to Database.");
        }

        public async Task Disconnect() {
            await Task.Delay(2500);
            Console.WriteLine("Disconnected from Database.");
        }
    }
}
