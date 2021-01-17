using System;
using System.Threading.Tasks;
using CreationalPatterns.Singleton;

namespace IngredientsDatabaseClient {
    internal class Program {
        private const string EastClientId = "US-East";
        private const string WestClientId = "US-West";
        private const string NorthClientId = "US-North";
        private const string SouthClientId = "US-South";
        /// <summary>
        /// This Program uses the Singleton pattern to share access to a global database connection pool.
        /// No matter which client requests access to the pool, each references the same Singleton instance.
        /// There are some significant downsides to this approach.  For instance, it is very difficult
        /// to test our client code because the constructor of the Singleton instance upon which our
        /// code depends is private.  We have no way to easily replace the Singleton with a mock object
        /// for testing purposes.  Furthermore, in multi-threaded contexts, we'll have to be careful to
        /// ensure multiple threads don't create multiple singleton objects.
        /// </summary>
        private static async Task Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("🥦  Connecting to ingredients database...");
            var eastClient = IngredientsDbConnectionPool.Instance;
            var westClient = IngredientsDbConnectionPool.Instance;
            var northClient = IngredientsDbConnectionPool.Instance;
            var southClient = IngredientsDbConnectionPool.Instance;

            // Open and close connections against the ConnectionPool
            await eastClient.Connect(EastClientId);
            await westClient.Connect(WestClientId);
            await northClient.Connect(NorthClientId);
            await southClient.Connect(SouthClientId);

            await northClient.Disconnect();
            await southClient.Connect(SouthClientId);

            await northClient.Disconnect();
            await northClient.Disconnect();
            await northClient.Disconnect();
            await northClient.Disconnect();

            Console.WriteLine("🥦  Session complete!");
        }
    }
}
