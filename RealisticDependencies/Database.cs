using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealisticDependencies {
    public interface IDatabase {
        Task Connect();
        Task Disconnect();
        Task<string> ReadData(string id);
        Task WriteData(string key, string data);
    }

    public class Database : IDatabase {
        private readonly string _connectionString;
        private bool _isConnected;
        private readonly Dictionary<string, string> _data = new();

        public Database(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task Connect() {
            await Task.Delay(2500);
            _isConnected = true;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{DateTime.UtcNow} - Connected to Database.");
            Console.ResetColor();
        }

        public async Task Disconnect() {
            await Task.Delay(2500);
            _isConnected = false;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{DateTime.UtcNow} - Disconnected from Database.");
            Console.ResetColor();
        }

        public async Task<string> ReadData(string id) {
            if (!_isConnected) {
                throw new NotSupportedException("Cannot read from database without open connection");
            }
            if (string.IsNullOrWhiteSpace(id)) { return ""; }
            await Task.Delay(500);
            try { return _data[id]; }
            catch (KeyNotFoundException) { return ""; }
        }

        public async Task WriteData(string key, string data)
        {
            if (!_isConnected) {
                throw new NotSupportedException("Cannot write to database without open connection");
            }
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(data)) { return; }
            await Task.Delay(250);
            _data[key] = data;
        }
    }
}
