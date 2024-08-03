using EngineLineLibrary.Connection;
using EngineLineLibrary.Connection.ExternalDependencies;
using FluentAssertions;
using Moq;
using System.Text;

namespace EngineLineLibraryTests.ConnectionTests
{
    public class SerialConnectionTests
    {
        private readonly Mock<ISerialPort> _serialPortMock;

        public SerialConnectionTests()
        {
            _serialPortMock = new Mock<ISerialPort>();
        }

        [Fact]
        public void Connect_ShouldReturnTrue_WhenConnectionIsEstablished()
        {
            _serialPortMock.Setup(m => m.Open())
                .Callback(() => _serialPortMock.SetupGet(m => m.IsOpen).Returns(true));

            var sut = new SerialConnection(_serialPortMock.Object);

            var result = sut.Connect("COM1");

            result.Should().BeTrue();
        }

        [Fact]
        public void Connect_ShouldReturnFalse_WhenConnectionFailsToEstablish()
        {
            var sut = new SerialConnection(_serialPortMock.Object);

            var result = sut.Connect("COM1");

            result.Should().BeFalse();
        }

        [Fact]
        public void Disconnect_ShouldReturnTrue_WhenSuccessfulyDisconnected()
        {
            _serialPortMock.SetupGet(m => m.IsOpen).Returns(true);
            _serialPortMock.Setup(m => m.Close())
                .Callback(() => _serialPortMock.SetupGet(m => m.IsOpen).Returns(false));

            var sut = new SerialConnection(_serialPortMock.Object);
            var result = sut.Disconnect();

            result.Should().BeTrue();
        }

        [Fact]
        public void Disconnect_ShouldReturnFalse_WhenItFailsToDisconnect()
        {
            _serialPortMock.SetupGet(m => m.IsOpen).Returns(true);

            var sut = new SerialConnection(_serialPortMock.Object);
            var result = sut.Disconnect();

            result.Should().BeFalse();
        }

        [Fact]
        public void SendMessage_ShouldReturnResponseMessage_WhenMessageIsSent()
        {
            _serialPortMock.SetupSequence(m => m.BaseStream)
                .Returns(new MemoryStream(Encoding.ASCII.GetBytes("ResponseMessage")))
                .Returns(new MemoryStream(Encoding.ASCII.GetBytes(">")));

            var sut = new SerialConnection(_serialPortMock.Object);

            var result = sut.SendMessage("TestMessage");

            result.Should().Be("ResponseMessage>");
        }
    }
}