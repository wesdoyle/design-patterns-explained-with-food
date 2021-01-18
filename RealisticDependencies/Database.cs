using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealisticDependencies {
    public interface IDatabase {
        Task Connect();
        Task Disconnect();
        Task<string> ReadData(string id);
        Task WriteData(string key, string data);
        Task<List<string>> DumpData();
    }

    public class Database : IDatabase {
        private readonly string _connectionString;
        private readonly IApplicationLogger _logger;
        private bool _isConnected;
        private readonly Dictionary<string, string> _data = new();

        public Database(string connectionString, IApplicationLogger logger) {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task Connect() {
            await Task.Delay(2500);
            _isConnected = true;
            _logger.LogInfo($"{DateTime.UtcNow} - Connected to Database.", ConsoleColor.Magenta);
        }

        public async Task Disconnect() {
            await Task.Delay(2500);
            _isConnected = false;
            _logger.LogInfo($"{DateTime.UtcNow} - Disconnected from Database.", ConsoleColor.Magenta);
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

        public async Task WriteData(string key, string data) {
            if (!_isConnected) {
                throw new NotSupportedException("Cannot write to database without open connection");
            }
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(data)) { return; }
            await Task.Delay(250);
            _data[key] = data;
        }

        public async Task<List<string>> DumpData() {
            if (!_isConnected) {
                throw new NotSupportedException("Cannot read from database without open connection");
            }
            await Task.Delay(2000);
            try { return _data.Values.Select(v => v).ToList(); 
            } catch (KeyNotFoundException) { 
                return new(); 
            }
        }
    }
}
