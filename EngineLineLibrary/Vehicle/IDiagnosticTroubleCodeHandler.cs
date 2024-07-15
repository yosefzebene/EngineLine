using EngineLineLibrary.Vehicle.Models;

namespace EngineLineLibrary.Vehicle
{
    public interface IDiagnosticTroubleCodeHandler
    {
        public List<DiagnosticTroubleCode> GetReportedDiagnosticTroubleCodes();
        public void ClearDiagnosticTroubleCodes();
    }
}
