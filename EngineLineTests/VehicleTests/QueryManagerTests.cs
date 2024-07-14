using EngineLine;
using EngineLine.Connection.Devices;
using EngineLine.Exceptions;
using EngineLine.Vehicle;
using FluentAssertions;
using Moq;

namespace EngineLineTests.VehicleTests
{
    public class QueryManagerTests
    {
        private Mock<IObd2Device> _deviceMock;

        public QueryManagerTests()
        {
            _deviceMock = new Mock<IObd2Device>();
        }
    }
}
