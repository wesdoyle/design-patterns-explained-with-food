using System;
using System.Threading.Tasks;
using CreationalPatterns.Singleton;

namespace IngredientsDatabaseClient {
    internal class Program {
        private const string EastClient = "US-East";
        private const string WestClient = "US-West";
        private const string NorthClient = "US-North";
        private const string SouthClient = "US-South";
        private static async Task Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("🥦  Connecting to ingredients database...");
            var connectionPoolEast = IngredientsDbConnectionPool.Instance;
            var connectionPoolWest = IngredientsDbConnectionPool.Instance;
            var connectionPoolNorth = IngredientsDbConnectionPool.Instance;
            var connectionPoolSouth = IngredientsDbConnectionPool.Instance;

            // Open and close connections against the ConnectionPool
            await connectionPoolEast.Connect(EastClient);
            await connectionPoolWest.Connect(WestClient);
            await connectionPoolNorth.Connect(NorthClient);
            await connectionPoolSouth.Connect(SouthClient);

            await connectionPoolNorth.Disconnect();
            await connectionPoolSouth.Connect(SouthClient);

            await connectionPoolNorth.Disconnect();
            await connectionPoolNorth.Disconnect();
            await connectionPoolNorth.Disconnect();
            await connectionPoolNorth.Disconnect();

            Console.WriteLine("🥦  Session complete!");
        }
    }
}
