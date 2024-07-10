namespace EngineLine.Connection.Devices
{
    public interface IObd2Device
    {
        public bool InitalizeDevice();
        public string Query(string command);
        public void Disconnect();
    }
}
