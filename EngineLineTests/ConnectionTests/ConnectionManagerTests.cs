using EngineLine.Connection;
using FluentAssertions;

namespace EngineLineTests.ConnectionTests
{
    public class ConnectionManagerTests
    {
        [Fact]
        public void CreateSerialConnection_ShouldReturnAnObd2DeviceInstance_WhenSuccessful()
        {
            var result = ConnectionManager.CreateSerialConnection("COM1", 38400);

            result.Should().NotBeNull();
        }
    }
}
