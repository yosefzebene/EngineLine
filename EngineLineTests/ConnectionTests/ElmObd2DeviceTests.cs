using EngineLine.Connection;
using EngineLine.Connection.Devices;
using FluentAssertions;
using Moq;

namespace EngineLineTests.ConnectionTests
{
    public class ElmObd2DeviceTests
    {
        [Fact]
        public void InitializeDevice_ShouldReturnTrue_WhenInitializationIsSuccessful()
        {
            var serialConnectionMock = new Mock<IConnection>();
            var sut = new ElmObd2Device(serialConnectionMock.Object);

            var result = sut.InitalizeDevice(It.IsAny<string>());

            result.Should().BeTrue();
        }
    }
}
