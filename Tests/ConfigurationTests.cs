using FluentAssertions;
using RealisticDependencies;
using Xunit;

namespace Tests {
    public class ConfigurationTests {
        [Fact]
        public void Connection_String_Is_Not_Null_Or_Empty() {
            var cxString = Configuration.ConnectionString;
            cxString.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void MaxConnections_Is_Greater_Than_Zero() {
            var max = Configuration.MaxConnections;
            max.Should().BeGreaterThan(0);
        }
    }
}
