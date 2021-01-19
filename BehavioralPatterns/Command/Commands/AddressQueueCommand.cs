using System;
using RealisticDependencies;

namespace BehavioralPatterns.Command.Commands {
    /// <summary>
    /// Delegates operations to an AMQP-style queue client
    /// </summary>
    public class AddressQueueCommand : ICommand {
        private readonly IApplicationLogger _logger;
        private readonly IAmqpQueue _queue;
        private readonly string _address;

        public AddressQueueCommand(IApplicationLogger logger, IAmqpQueue queue, string address) {
            _logger = logger;
            _queue = queue;
            _address = address;
        }

        public void Execute() {
            _logger.LogInfo("Adding User Address to Compost AWS Queue", ConsoleColor.Blue);
            _queue.Add(new QueueMessage(_address));
        }
    }
}
