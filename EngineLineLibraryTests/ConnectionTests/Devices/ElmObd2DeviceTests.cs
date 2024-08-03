using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Connection;
using EngineLineLibrary.Exceptions;
using FluentAssertions;
using Moq;

namespace EngineLineLibraryTests.ConnectionTests.Devices
{
    public class ElmObd2DeviceTests
    {
        private readonly Mock<IConnection> _connectionMock;

        public ElmObd2DeviceTests()
        {
            _connectionMock = new Mock<IConnection>();
        }

        [Fact]
        public void InitalizeDevice_ShouldReturnTrue_WhenSuccessfullyInitialized()
        {
            var response = "Successful";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            var result = sut.InitalizeDevice();

            result.Should().BeTrue();
        }

        [Fact]
        public void Query_ShouldReturnAString_WhenGivenACommand()
        {
            var response = "Successful";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            sut.InitalizeDevice();
            var result = sut.Query("query");

            result.Should().Be(response);
        }

        [Fact]
        public void Query_ShouldThrowInvalidCommandReceivedException_WhenVehicleRespondsWithQuestionMark()
        {
            var response = "\r\n?\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<InvalidCommandReceivedException>()
                .WithMessage("The command is not valid");
        }

        [Fact]
        public void Query_ShouldThrowVehicleConnectionException_WhenVehicleRespondsWithBusBusy()
        {
            var response = "\r\nBUS BUSY\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<VehicleConnectionException>()
                .WithMessage("To much activity on the bus to send a message");
        }

        [Fact]
        public void Query_ShouldThrowVehicleConnectionException_WhenVehicleRespondsWithBusError()
        {
            var response = "\r\nBUS ERROR\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<VehicleConnectionException>()
                .WithMessage("A generic problem has occurred");
        }

        [Fact]
        public void Query_ShouldThrowVehicleConnectionException_WhenVehicleRespondsWithCanError()
        {
            var response = "\r\nCAN ERROR\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<VehicleConnectionException>()
                .WithMessage("The CAN system had difficulty initializing, sending, or receiving");
        }

        [Fact]
        public void Query_ShouldThrowVehicleDataException_WhenVehicleRespondsWithDataError()
        {
            var response = "\r\nDATA ERROR\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<VehicleDataException>()
                .WithMessage("Data from vehicle was invalid or could not be recovered");
        }

        [Fact]
        public void Query_ShouldThrowVehicleDataException_WhenVehicleRespondsWithNoData()
        {
            var response = "\r\nNO DATA\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<VehicleDataException>()
                .WithMessage("No data was received from the vehicle");
        }

        [Fact]
        public void Query_ShouldThrowVehicleConnectionException_WhenVehicleRespondsWithUnableToConnect()
        {
            var response = "\r\nUNABLE TO CONNECT\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<VehicleConnectionException>()
                .WithMessage("Connection with the vehicle could not be established");
        }

        [Fact]
        public void Query_ShouldThrowVehicleConnectionException_WhenVehicleRespondsWithSearchingUnableToConnect()
        {
            var response = "\r\nSEARCHING...\r\nUNABLE TO CONNECT\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<VehicleConnectionException>()
                .WithMessage("Connection with the vehicle could not be established");
        }

        [Fact]
        public void Query_ShouldThrowVehicleConnectionException_WhenVehicleRespondsWithStopped()
        {
            var response = "\r\nSTOPPED\r\n>";
            _connectionMock.Setup(m => m.SendMessage(It.IsAny<string>())).Returns(response);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            Action act = () => sut.InitalizeDevice();

            act.Should().Throw<VehicleConnectionException>()
                .WithMessage("The OBD operation has be interrupted");
        }

        [Fact]
        public void Disconnect_ShouldDisconnectFromDevice()
        {
            _connectionMock.Setup(m => m.Disconnect()).Returns(true);

            var sut = new ElmObd2Device(_connectionMock.Object, It.IsAny<int>());
            var result = sut.Disconnect();

            result.Should().BeTrue();
        }
    }
}
