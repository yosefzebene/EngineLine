using EngineLineLibrary.Connection.Devices;
using Moq;

namespace EngineLineLibraryTests.VehicleTests
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
