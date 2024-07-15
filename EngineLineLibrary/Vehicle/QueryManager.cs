using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Models;

namespace EngineLineLibrary.Vehicle
{
    public class QueryManager
    {
        private readonly IObd2Device _device;
        private readonly IVehicleDataRetriever _vehicleDataRetriever;
        private readonly IDiagnosticTroubleCodeHandler _dtcHandler;

        public QueryManager(IObd2Device device)
        {
            _device = device;
            _vehicleDataRetriever = new VehicleDataRetriever(device);
            _dtcHandler = new DiagnosticTroubleCodeHandler(device);
        }

        public Pid[] GetSupportedCommands()
        {
            return _vehicleDataRetriever.GetSupportedCommands();
        }

        public decimal GetVehicleData(Pid pid)
        {
            return _vehicleDataRetriever.GetVehicleData(pid);
        }

        //public void GetVehicleStatus()
        //{

        //}

        //// Mode 2
        //public string GetFreezeFrameDiagnosticTroubleCode()
        //{
        //    return "";
        //}

        // Mode 3
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
