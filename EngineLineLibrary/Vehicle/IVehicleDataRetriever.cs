using EngineLineLibrary.Vehicle.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLineLibrary.Vehicle
{
    public interface IVehicleDataRetriever
    {
        public Pid[] GetSupportedCommands();
        public decimal GetVehicleData(Pid pid);
    }
}
