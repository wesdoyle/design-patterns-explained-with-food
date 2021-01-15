using System;
using System.Threading.Tasks;
using RealisticDependencies;

namespace CreationalPatterns.Singleton {
    public class IngredientsDbConnectionPool {

        private IngredientsDbConnectionPool() {
            _database = new Database(Configuration.ConnectionString);
        }

        private int _openConnections = 0;

        private readonly Database _database;

        private static readonly Lazy<IngredientsDbConnectionPool> _instance = new (() => new IngredientsDbConnectionPool());

        public static IngredientsDbConnectionPool Instance => _instance.Value;

        public async Task Connect(string client) {
            if (_openConnections >= Configuration.MaxConnections) {
                Console.WriteLine("ERROR - Cannot acquire new connection. " +
                                  $"Max connections of {Configuration.MaxConnections} " +
                                  "is met or exceeded.");
                return;
            }

            _openConnections++;
            Console.WriteLine($"Added connection to pool from: {client}");
            await _database.Connect();
        }

        public async Task Disconnect() {
            if (_openConnections <= 0) {
                Console.WriteLine("There are no connections to close.");
                return;
            }

            _openConnections--;
            Console.WriteLine("Released connection. Now managing " +
                              $"({_openConnections}) open connections.");
            await _database.Disconnect();
        }
    }
}
