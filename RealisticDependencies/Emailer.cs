using System;
using System.Threading.Tasks;

namespace RealisticDependencies {
    public class EmailMessage {
        public string To { get; set; }
        public string Content { get; set; }
        public EmailMessage(string to, string content) {
            To = to;
            Content = content;
        }
    }

    public interface ISendsEmails {
        public Task SendMessage(EmailMessage message);
    }

    public class Emailer : ISendsEmails {
        private readonly IApplicationLogger _logger;

        public Emailer(IApplicationLogger logger) { _logger = logger; }

        public async Task SendMessage(EmailMessage message) {
            await Task.Delay(1000);
            _logger.LogInfo($"Sent email to: {message.To} with Message: {message.Content}", ConsoleColor.Cyan);
        }
    }
}
