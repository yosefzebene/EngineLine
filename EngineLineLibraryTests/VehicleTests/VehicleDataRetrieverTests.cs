using EngineLineLibrary.Exceptions;
using EngineLineLibrary.Vehicle;
using EngineLineLibrary.Vehicle.Models;
using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Vehicle.Enums;
using FluentAssertions;
using Moq;

namespace EngineLineLibraryTests.VehicleTests
{
    public class VehicleDataRetrieverTests
    {
        private Mock<IObd2Device> _deviceMock;

        public VehicleDataRetrieverTests()
        {
            _deviceMock = new Mock<IObd2Device>();
        }

        [Fact]
        public void GetSupportedCommands_ShouldReturnAnArrayOfSupportedPids()
        {
            _deviceMock.Setup(m => m.Query(It.IsAny<string>())).Returns("41 00 80 00 00 00");

            var expected = new Pid[]
            {
                Pid.MonitorStatusSinceDtcCleared,
                Pid.DistanceTravelSinceCheckEngineLightOn,
            };

            var sut = new VehicleDataRetriever(_deviceMock.Object);
            var result = sut.GetSupportedCommands();

            result.Length.Should().Be(expected.Length);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact(Skip = "The logger hasn't been implemented yet so I can't test this.")]
        public void GetSupportedCommands_ShouldHandleInvalidCommandReceivedExceptionByLoggingIt_WhenItIsThrownByTheQueryFunction()
        {
            _deviceMock.Setup(m => m.Query(It.IsAny<string>()))
                .Throws(new InvalidCommandReceivedException("Test message"));

            var sut = new VehicleDataRetriever(_deviceMock.Object);
            var result = sut.GetSupportedCommands();

            //NOTE: This should check that the logger function has been called once I setup the logger
            result.Length.Should().Be(0);
        }

        [Fact]
        public void GetVehicleData_ShouldReturnTheRequestedData_WhenEngineSpeedPidIsPassed()
        {
            _deviceMock.Setup(m => m.Query(It.IsAny<string>())).Returns("41 0C ff ff");

            var service = Service.CurrentData;
            var request = Pid.EngineSpeed;

            var sut = new VehicleDataRetriever(_deviceMock.Object);
            var result = sut.GetVehicleData(service, request);

            var expected = new PidData()
            {
                PidName = "Engine Speed",
                Result = 16384m,
                Unit = "rpm"
            };

            result.PidName.Should().Be(expected.PidName);
            result.Result.Should().Be(expected.Result);
            result.Unit.Should().Be(expected.Unit);
        }
    }
}
