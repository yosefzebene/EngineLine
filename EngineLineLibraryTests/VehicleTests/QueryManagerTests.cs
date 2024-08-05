using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Vehicle;
using EngineLineLibrary.Vehicle.Enums;
using FluentAssertions;
using Moq;

namespace EngineLineLibraryTests.VehicleTests
{
    public class QueryManagerTests
    {
        private Mock<IObd2Device> _device;
        private Mock<IVehicleDataRetriever> _vehicleDataRetrieverMock;
        private Mock<IDiagnosticTroubleCodeHandler> _dtcHandlerMock;
        private Mock<IMonitorStatusRetriever> _monitorStatusRetrieverMock;

        public QueryManagerTests()
        {
            _device = new Mock<IObd2Device>();
            _vehicleDataRetrieverMock = new Mock<IVehicleDataRetriever>();
            _dtcHandlerMock = new Mock<IDiagnosticTroubleCodeHandler>();
            _monitorStatusRetrieverMock = new Mock<IMonitorStatusRetriever>();
        }

        [Fact]
        public void QueryManager_ShouldSucessfulyCreateAnInstanceOfQueryManager_WhenPassedADevice()
        {
            var sut = new QueryManager(_device.Object);

            sut.Should().BeOfType<QueryManager>();
        }

        [Fact]
        public void GetSupportedCommands_ShouldInvokeGetSupportedCommandsMethodOnIVehicleDataRetriever()
        {
            _vehicleDataRetrieverMock.Setup(m => m.GetSupportedCommands());

            var sut = new QueryManager(_vehicleDataRetrieverMock.Object, _dtcHandlerMock.Object, _monitorStatusRetrieverMock.Object);
            sut.GetSupportedCommands();

            _vehicleDataRetrieverMock.Verify(m => m.GetSupportedCommands(), Times.Once());
        }

        [Fact]
        public void GetCurrentData_ShouldInvokeGetVehicleDataMethodOnIVehicleDataRetriever_WithCurrentDataModeAndThePassedPid()
        {
            Service expectedService = Service.CurrentData;
            Pid expectedPid = Pid.EngineSpeed;

            _vehicleDataRetrieverMock.Setup(m => m.GetVehicleData(It.IsAny<Service>(), It.IsAny<Pid>()));

            var sut = new QueryManager(_vehicleDataRetrieverMock.Object, _dtcHandlerMock.Object, _monitorStatusRetrieverMock.Object);
            sut.GetCurrentData(expectedPid);

            _vehicleDataRetrieverMock.Verify(m => m.GetVehicleData(expectedService, expectedPid), Times.Once());
        }

        [Fact]
        public void GetFreezeFrameData_ShouldInvokeGetVehicleDataMethodOnIVehicleDataRetriever_WithFreezeFrameDataModeAndThePassedPid()
        {
            Service expectedService = Service.FreezeFrameData;
            Pid expectedPid = Pid.EngineSpeed;

            _vehicleDataRetrieverMock.Setup(m => m.GetVehicleData(It.IsAny<Service>(), It.IsAny<Pid>()));

            var sut = new QueryManager(_vehicleDataRetrieverMock.Object, _dtcHandlerMock.Object, _monitorStatusRetrieverMock.Object);
            sut.GetFreezeFrameData(expectedPid);

            _vehicleDataRetrieverMock.Verify(m => m.GetVehicleData(expectedService, expectedPid), Times.Once());
        }

        [Fact]
        public void GetVehicleMonitorStatus_ShouldInvokeGetMonitorStatusOnIMonitorStatusRetriever()
        {
            _monitorStatusRetrieverMock.Setup(m => m.GetMonitorStatus());

            var sut = new QueryManager(_vehicleDataRetrieverMock.Object, _dtcHandlerMock.Object, _monitorStatusRetrieverMock.Object);
            sut.GetVehicleMonitorStatus();

            _monitorStatusRetrieverMock.Verify(m => m.GetMonitorStatus(), Times.Once());
        }

        [Fact]
        public void GetFreezeFrameDiagnosticTroubleCode_ShouldInvokeGetFreezeFrameDiagnosticTroubleCodeOnIDiagnosticTroubleCodeHandler()
        {
            _dtcHandlerMock.Setup(m => m.GetFreezeFrameDiagnosticTroubleCode());

            var sut = new QueryManager(_vehicleDataRetrieverMock.Object, _dtcHandlerMock.Object, _monitorStatusRetrieverMock.Object);
            sut.GetFreezeFrameDiagnosticTroubleCode();

            _dtcHandlerMock.Verify(m => m.GetFreezeFrameDiagnosticTroubleCode(), Times.Once());
        }

        [Fact]
        public void GetReportedDiagnosticTroubleCodes_ShouldInvokeGetReportedDiagnosticTroubleCodesOnIDiagnosticTroubleCodeHandler()
        {
            _dtcHandlerMock.Setup(m => m.GetReportedDiagnosticTroubleCodes());

            var sut = new QueryManager(_vehicleDataRetrieverMock.Object, _dtcHandlerMock.Object, _monitorStatusRetrieverMock.Object);
            sut.GetReportedDiagnosticTroubleCodes();

            _dtcHandlerMock.Verify(m => m.GetReportedDiagnosticTroubleCodes(), Times.Once());
        }

        [Fact]
        public void ClearDiagnosticTroubleCodes_ShouldInvokeClearDiagnosticTroubleCodesOnIDiagnosticTroubleCodeHandler()
        {
            _dtcHandlerMock.Setup(m => m.ClearDiagnosticTroubleCodes());

            var sut = new QueryManager(_vehicleDataRetrieverMock.Object, _dtcHandlerMock.Object, _monitorStatusRetrieverMock.Object);
            sut.ClearDiagnosticTroubleCodes();

            _dtcHandlerMock.Verify(m => m.ClearDiagnosticTroubleCodes(), Times.Once());
        }
    }
}
