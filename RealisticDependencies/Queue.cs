using System;

namespace RealisticDependencies {
    public class QueueMessage {
        public string Content { get; private set; }
        public QueueMessage(string content) {
            Content = content;
        }
    }

    public interface IAmqpQueue {
        public void Add(QueueMessage item);
    }

    public class CloudQueue : IAmqpQueue {
        public void Add(QueueMessage item) {
            Console.WriteLine($"Added to queue: {item.Content}");
        }
    }
}
