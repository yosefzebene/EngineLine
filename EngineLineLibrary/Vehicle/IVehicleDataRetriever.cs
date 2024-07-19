using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Models;

namespace EngineLineLibrary.Vehicle
{
    public interface IVehicleDataRetriever
    {
        public Pid[] GetSupportedCommands();
        public decimal GetVehicleData(Service service, Pid pid);
    }
}
