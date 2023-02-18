using Moq;
using RealisticDependencies;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests {
    public class EmailerTests {
        [Fact]
        public async Task SendMessage_Logs_Email_Content() {
            // Arrange
            var mockLogger = new Mock<IApplicationLogger>();
            var emailer = new Emailer(mockLogger.Object);
            var email = new EmailMessage("fooo", "bar");

            // Act 
            await emailer.SendMessage(email);

            // Assert 
            mockLogger.Verify(mock
                => mock.LogInfo(
                    It.Is<string>(s => s.Contains(email.Content)),
                    It.IsAny<ConsoleColor>()),
                Times.Once());
        }
    }
}
