using System.IO.Ports;

namespace EngineLine.Connection.ExternalDependencies
{
    public interface ISerialPort
    {
        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public Parity Parity { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public Handshake Handshake { get; set; }

        public void Open();
        public void Close();
        public void WriteLine(string message);
        public string ReadExisting();
    }
}
