using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RealisticDependencies;

namespace StructuralPatterns.Decorator.Decorators {
    public class SmsMessageDecorator : NotificationDecorator {

        private readonly IAmqpQueue _queue; 

        public SmsMessageDecorator(Notifier component, IAmqpQueue queue) : base(component) {
            _queue = queue;
        }

        public override Task HandleTableReadyMessage() {
            Task.FromResult(base.HandleTableReadyMessage());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(":: SMS - Queueing up a text message");
            Console.ResetColor();
            var message = new { customerName = "Sandi", message = "Your table is ready!" };
            var jsonMessage = JsonConvert.SerializeObject(message);
            var queueMessage = new QueueMessage(jsonMessage);
            _queue.Add(queueMessage);
            return Task.CompletedTask;
        }
    }
}
