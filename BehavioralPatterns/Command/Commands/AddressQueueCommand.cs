using System;
using RealisticDependencies;

namespace BehavioralPatterns.Command.Commands {
    /// <summary>
    /// Delegates operations to an AMQP-style queue client
    /// </summary>
    public class AddressQueueCommand : ICommand {
        private readonly IAmqpQueue _queue;
        private readonly string _address;

        public AddressQueueCommand(IAmqpQueue queue, string address) {
            _queue = queue;
            _address = address;
        }

        public void Execute() {
            Console.WriteLine("Adding User Address to Compost AWS Queue");
            _queue.Add(new QueueMessage(_address));
        }
    }
}
