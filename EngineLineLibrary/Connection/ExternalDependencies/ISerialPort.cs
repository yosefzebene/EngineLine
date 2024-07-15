using System.IO.Ports;

namespace EngineLineLibrary.Connection.ExternalDependencies
{
    public interface ISerialPort
    {
        public bool IsOpen { get; }
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake Handshake { get; set; }
        public event SerialDataReceivedEventHandler DataReceived;

        public void Open();
        public void Close();
        public void WriteLine(string message);
        public string ReadExisting();
        public string[] GetPortNames();
    }
}
