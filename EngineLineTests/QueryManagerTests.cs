using EngineLine;
using EngineLine.Connection.Devices;
using EngineLine.Exceptions;
using FluentAssertions;
using Moq;

namespace EngineLineTests
{
    public class QueryManagerTests
    {
        [Fact]
        public void GetSupportedCommands_ShouldReturnAnArrayOfSupportedPids()
        {
            var obd2DeviceMock = new Mock<IObd2Device>();
            obd2DeviceMock.Setup(m => m.Query(It.IsAny<string>())).Returns("41 00 80 00 00 00");

            var expected = new Pid[]
            {
                Pid.MonitorStatusSinceDtcCleared,
                Pid.DistanceTravelSinceCheckEngineLightOn,
            };

            var sut = new QueryManager(obd2DeviceMock.Object);
            var result = sut.GetSupportedCommands();

            result.Length.Should().Be(expected.Length);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact (Skip = "The logger hasn't been implemented yet so I can't test this.")]
        public void GetSupportedCommands_ShouldHandleInvalidCommandReceivedExceptionByLoggingIt_WhenItIsThrownByTheQueryFunction()
        {
            var obd2DeviceMock = new Mock<IObd2Device>();
            obd2DeviceMock.Setup(m => m.Query(It.IsAny<string>()))
                .Throws(new InvalidCommandReceivedException("Test message"));

            var sut = new QueryManager(obd2DeviceMock.Object);
            var result = sut.GetSupportedCommands();

            //NOTE: This should check that the logger function has been called once I setup the logger
            result.Length.Should().Be(0);
        }
    }
}
