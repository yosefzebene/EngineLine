using Castle.Components.DictionaryAdapter;
using EngineLine.Connection;
using EngineLine.Connection.ExternalDependencies;
using FluentAssertions;
using Moq;
using System.IO.Ports;

namespace EngineLineTests.ConnectionTests
{
    public class SerialConnectionTests
    {
        [Fact]
        public void Connect_ShouldReturnTrue_WhenConnectionIsEstablished()
        {
            var serialPortMock = new Mock<ISerialPort>();
            serialPortMock.Setup(m => m.Open())
                .Callback(() => serialPortMock.SetupGet(m => m.IsOpen).Returns(true));

            var port = "COM1";
            var sut = new SerialConnection(serialPortMock.Object, port);

            var result = sut.Connect();

            result.Should().BeTrue();
            sut.GetConnectionStatus().Should().BeTrue();
        }

        [Fact]
        public void Connect_ShouldReturnFalse_WhenConnectionFailsToEstablish()
        {
            var serialPortMock = new Mock<ISerialPort>();
            serialPortMock.Setup(m => m.Open()).Throws(new Exception());

            var port = "COM1";
            var sut = new SerialConnection(serialPortMock.Object, port);

            var result = sut.Connect();

            result.Should().BeFalse();
            sut.GetConnectionStatus().Should().BeFalse();
        }

        [Fact]
        public void Disconnect_ShouldReturnTrue_WhenItIsDisconnected()
        {
            var serialPortMock = new Mock<ISerialPort>();

            var port = "COM1";
            var sut = new SerialConnection(serialPortMock.Object, port);

            var result = sut.Disconnect();

            result.Should().BeTrue();
        }

        [Fact]
        public void Disconnect_ShouldReturnFalse_WhenItFailsToDisconnect()
        {
            var serialPortMock = new Mock<ISerialPort>();
            serialPortMock.Setup(m => m.Close()).Throws(new Exception());
 
            var port = "COM1";
            var sut = new SerialConnection(serialPortMock.Object, port);

            var result = sut.Disconnect();

            result.Should().BeFalse();
        }

        [Fact]
        public void GetConnectionStatus_ShouldReturnFalse_WhenTheSerialConnectionIsNotEstablished()
        {
            var serialPortMock = new Mock<ISerialPort>();

            var port = "COM1";
            var sut = new SerialConnection(serialPortMock.Object, port);

            var result = sut.GetConnectionStatus();

            result.Should().BeFalse();
        }

        [Fact]
        public void GetConnectionStatus_ShouldReturnTrue_WhenTheSerialConnectionIsEstablished()
        {
            var serialPortMock = new Mock<ISerialPort>();
            serialPortMock.Setup(m => m.Open())
                .Callback(() => serialPortMock.SetupGet(m => m.IsOpen).Returns(true));

            var port = "COM1";
            var sut = new SerialConnection(serialPortMock.Object, port);

            sut.Connect();
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

            var port = "COM1";
            var sut = new SerialConnection(serialPortMock.Object, port);

            var result = sut.SendMessage("TestMessage");

            result.Should().BeSameAs("ResponseMessage>");
        }
    }
}