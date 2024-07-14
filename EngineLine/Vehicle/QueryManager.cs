using EngineLine.Connection.Devices;
using EngineLine.Vehicle.Enums;
using EngineLine.Vehicle.Models;

namespace EngineLine.Vehicle
{
    public class QueryManager
    {
        private readonly IObd2Device _device;

        private readonly VehicleDataRetriever vehicleDataRetriever;
        private readonly DiagnosticTroubleCodeHandler dtcHandler;

        public QueryManager(IObd2Device device)
        {
            _device = device;
            vehicleDataRetriever = new VehicleDataRetriever(_device);
            dtcHandler = new DiagnosticTroubleCodeHandler(_device);

        }

        public Pid[] GetSupportedCommands()
        {
            return vehicleDataRetriever.GetSupportedCommands();
        }

        public decimal GetVehicleData(Pid pid)
        {
            return vehicleDataRetriever.GetVehicleData(pid);
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
            return dtcHandler.GetReportedDiagnosticTroubleCodes();
        }

        public void ClearDiagnosticTroubleCodes()
        {
            dtcHandler.ClearDiagnosticTroubleCodes();
        }
    }
}
