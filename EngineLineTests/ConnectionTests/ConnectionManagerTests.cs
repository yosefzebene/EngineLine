using EngineLine.Connection;
using EngineLine.Connection.Devices;
using EngineLine.Connection.ExternalDependencies;
using FluentAssertions;
using Moq;

namespace EngineLineTests.ConnectionTests
{
    public class ConnectionManagerTests
    {
        [Fact]
        public void CreateSerialConnection_ShouldReturnAnObd2DeviceInstance_WhenSuccessful()
        {
            var serialPortMock = new Mock<ISerialPort>();
            var sut = new ConnectionManager(serialPortMock.Object);
            
            var result = sut.CreateSerialConnection("COM1", 38400, It.IsAny<string>());

            result.Should().BeOfType<ElmObd2Device>();
        }

        [Fact]
        public void GetAvailableSerialDevices_ShouldReturnListOfComPortsOnly()
        {
            var ports = new string[]
            {
                "COM1",
                "COM3",
                "COM5",
                "OTHERPORT"
            };
            var expectedPorts = new string[]
            {
                "COM1",
                "COM3",
                "COM5"
            };

            var serialPortMock = new Mock<ISerialPort>();
            serialPortMock.Setup(m => m.GetPortNames()).Returns(ports);
            var sut = new ConnectionManager(serialPortMock.Object);

            var result = sut.GetAvailableSerialDevices();

            result.Should().HaveCount(expectedPorts.Length);
            result.Should().Contain(expectedPorts);
        }
    }
}
