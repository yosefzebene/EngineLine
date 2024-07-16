namespace EngineLineLibrary.Vehicle.Models
{
    public class MonitorStatus
    {
        public bool CheckEngineLightOn { get; set; }
        public int NumberOfDtcs { get; set; }
        public string EngineType { get; set; }
        public List<ReadinessCheck> ReadinessChecks { get; set; }
    }
}
