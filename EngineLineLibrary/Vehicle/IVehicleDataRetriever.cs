using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Models;

namespace EngineLineLibrary.Vehicle
{
    public interface IVehicleDataRetriever
    {
        public Pid[] GetSupportedCommands();
        public PidData GetVehicleData(Service service, Pid pid);
    }
}
