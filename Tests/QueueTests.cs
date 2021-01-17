using Moq;
using RealisticDependencies;
using System;
using Xunit;

namespace Tests {
    public class QueueTests {
        [Fact]
        public void Add_Invokes_Log_Message() {
            // Arrange
            var logger = new Mock<IApplicationLogger>();
            var queue = new CloudQueue(logger.Object);
            var payload = new QueueMessage("hello");

            // Act 
            queue.Add(payload);

            // Assert 
            logger.Verify(mock
                => mock.LogInfo(
                    It.Is<string>(s => s.Contains(payload.Content)),
                    It.IsAny<ConsoleColor>()),
                Times.Once());
        }
    }
}
