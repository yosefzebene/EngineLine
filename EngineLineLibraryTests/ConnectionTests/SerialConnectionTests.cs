using EngineLineLibrary.Connection;
using EngineLineLibrary.Connection.ExternalDependencies;
using FluentAssertions;
using Moq;
using System.IO.Ports;

namespace EngineLineLibraryTests.ConnectionTests
{
    public class SerialConnectionTests
    {
        [Fact]
        public void Connect_ShouldReturnTrue_WhenConnectionIsEstablished()
        {
            var serialPortMock = new Mock<ISerialPort>();
            serialPortMock.Setup(m => m.Open())
                .Callback(() => serialPortMock.SetupGet(m => m.IsOpen).Returns(true));

            var sut = new SerialConnection(serialPortMock.Object);

            var result = sut.Connect("COM1");

            result.Should().BeTrue();
            sut.GetConnectionStatus().Should().BeTrue();
        }

        [Fact]
        public void Connect_ShouldReturnFalse_WhenConnectionFailsToEstablish()
        {
            var serialPortMock = new Mock<ISerialPort>();

            var sut = new SerialConnection(serialPortMock.Object);

            var result = sut.Connect("COM1");

            result.Should().BeFalse();
        }

        [Fact]
        public void GetConnectionStatus_ShouldReturnFalse_WhenTheSerialConnectionIsNotEstablished()
        {
            var serialPortMock = new Mock<ISerialPort>();

            var sut = new SerialConnection(serialPortMock.Object);

            var result = sut.GetConnectionStatus();

            result.Should().BeFalse();
        }

        [Fact]
        public void GetConnectionStatus_ShouldReturnTrue_WhenTheSerialConnectionIsEstablished()
        {
            var serialPortMock = new Mock<ISerialPort>();
            serialPortMock.Setup(m => m.Open())
                .Callback(() => serialPortMock.SetupGet(m => m.IsOpen).Returns(true));

            var sut = new SerialConnection(serialPortMock.Object);

            sut.Connect("COM1");
            var result = sut.GetConnectionStatus();

            result.Should().BeTrue();
        }

        [Fact]
        public void SendMessage_ShouldReturnResponseMessage_WhenMessageIsSent()
        {
            var serialPortMock = new Mock<ISerialPort>();
            serialPortMock.Setup(m => m.ReadExisting()).Returns("ResponseMessage>");
            serialPortMock.Setup(m => m.WriteLine(It.IsAny<string>()))
                          .Raises(m => m.DataReceived += null, serialPortMock.Object, It.IsAny<SerialDataReceivedEventArgs>());

            var sut = new SerialConnection(serialPortMock.Object);

            var result = sut.SendMessage("TestMessage");

            result.Should().BeSameAs("ResponseMessage>");
        }
    }
}