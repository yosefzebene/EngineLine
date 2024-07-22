using EngineLineLibrary.Vehicle.Models;

namespace EngineLineLibrary.Vehicle
{
    public interface IMonitorStatusRetriever
    {
        public MonitorStatus GetMonitorStatus();
    }
}
