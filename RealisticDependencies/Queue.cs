using System;
using System.Threading;

namespace RealisticDependencies {
    public class QueueMessage {
        public string Content { get; }
        public QueueMessage(string content) {
            Content = content;
        }
    }

    public interface IAmqpQueue {
        public void Add(QueueMessage item);
    }

    public class CloudQueue : IAmqpQueue {
        private readonly IApplicationLogger _logger;

        public CloudQueue(IApplicationLogger logger) {
            _logger = logger;
        }

        public void Add(QueueMessage item) {
            Thread.Sleep(250);
            _logger.LogInfo($"Added to queue: {item.Content}", ConsoleColor.Magenta);
        }
    }
}
