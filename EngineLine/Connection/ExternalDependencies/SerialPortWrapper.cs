using System.IO.Ports;

namespace EngineLine.Connection.ExternalDependencies
{
    public class SerialPortWrapper : ISerialPort
    {
        private readonly SerialPort _serialPort;

        public string PortName 
        {
            get { return _serialPort.PortName; }
            set { _serialPort.PortName = value; }
        }

        public int BaudRate
        {
            get { return _serialPort.BaudRate; }
            set { _serialPort.BaudRate = value; }
        }

        public Parity Parity
        {
            get { return _serialPort.Parity; }
            set { _serialPort.Parity = value; }
        }

        public int DataBits
        {
            get { return _serialPort.DataBits; }
            set { _serialPort.DataBits = value; }
        }
        
        public StopBits StopBits
        {
            get { return _serialPort.StopBits; }
            set { _serialPort.StopBits = value; }
        }

        public Handshake Handshake
        {
            get { return _serialPort.Handshake; }
            set { _serialPort.Handshake = value; }
        }

        public SerialPortWrapper() { _serialPort = new(); }

        public void Open() { _serialPort.Open(); }

        public void Close() { _serialPort.Close(); }

        public void WriteLine(string message) { _serialPort.WriteLine(message); }

        public string ReadExisting() { return _serialPort.ReadExisting(); }
    }
}
