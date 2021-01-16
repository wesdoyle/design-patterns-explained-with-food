using System;
using System.Threading.Tasks;

namespace StructuralPatterns.Decorator {
    public class CustomerNotifier : Notifier {
        public override Task HandleTableReadyMessage() {
            Console.WriteLine("Your table is ready!");
            return Task.CompletedTask;
        }
    }
}
