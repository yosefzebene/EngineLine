namespace EngineLineLibrary
{
    public class ReadinessMonitorStatus
    {   
        public string Name { get; set; }
        public bool Available { get; set; }
        public bool Incomplete { get; set; }
        public bool CurrentDriveCheckAvailable { get; set; }
        public bool IncompleteCurrentDriveCycle { get; set; }
    }    
}
