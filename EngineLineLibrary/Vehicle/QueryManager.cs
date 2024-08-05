using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Models;

namespace EngineLineLibrary.Vehicle
{
    public class QueryManager
    {
        private readonly IVehicleDataRetriever _vehicleDataRetriever;
        private readonly IDiagnosticTroubleCodeHandler _dtcHandler;
        private readonly IMonitorStatusRetriever _monitorStatusRetriever;

        public QueryManager(IObd2Device device)
        {
            _vehicleDataRetriever = new VehicleDataRetriever(device);
            _dtcHandler = new DiagnosticTroubleCodeHandler(device);
            _monitorStatusRetriever = new MonitorStatusRetriever(device);
        }

        public QueryManager(IVehicleDataRetriever vehicleDataRetriever, IDiagnosticTroubleCodeHandler dtcHandler, IMonitorStatusRetriever monitorStatusRetriever)
        {
            _vehicleDataRetriever = vehicleDataRetriever;
            _dtcHandler = dtcHandler;
            _monitorStatusRetriever = monitorStatusRetriever;
        }

        public Pid[] GetSupportedCommands()
        {
            return _vehicleDataRetriever.GetSupportedCommands();
        }

        public PidData GetCurrentData(Pid pid)
        {
            return _vehicleDataRetriever.GetVehicleData(Service.CurrentData, pid);
        }

        public PidData GetFreezeFrameData(Pid pid)
        {
            return _vehicleDataRetriever.GetVehicleData(Service.FreezeFrameData, pid);
        }

        public MonitorStatus GetVehicleMonitorStatus()
        {
            return _monitorStatusRetriever.GetMonitorStatus();
        }

        public DiagnosticTroubleCode GetFreezeFrameDiagnosticTroubleCode()
        {
            return _dtcHandler.GetFreezeFrameDiagnosticTroubleCode();
        }

        public List<DiagnosticTroubleCode> GetReportedDiagnosticTroubleCodes()
        {
            return _dtcHandler.GetReportedDiagnosticTroubleCodes();
        }

        public void ClearDiagnosticTroubleCodes()
        {
            _dtcHandler.ClearDiagnosticTroubleCodes();
        }
    }
}
