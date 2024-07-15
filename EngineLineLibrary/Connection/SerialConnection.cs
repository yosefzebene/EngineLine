using EngineLineLibrary.Connection.ExternalDependencies;
using System.IO.Ports;

namespace EngineLineLibrary.Connection
{
    public class SerialConnection : IConnection
    {
        private const int DEFAULT_BAUD = 38400;

        private readonly ISerialPort _serialPort;
        private string buffer = "";

        public SerialConnection(ISerialPort serialPort)
        {
            _serialPort = serialPort;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);
        }

        public bool Connect(string port, int baudRate = DEFAULT_BAUD)
        {
            _serialPort.PortName = port;
            _serialPort.BaudRate = baudRate;
            _serialPort.Open();

            return _serialPort.IsOpen;
        }

        public void Disconnect()
        {
            _serialPort.Close();
        }

        public bool GetConnectionStatus()
        {
            return _serialPort.IsOpen;
        }

        public string SendMessage(string message)
        {
            buffer = "";

            _serialPort.WriteLine(string.Format("{0}{1}", message, "\r"));

            while (!buffer.Contains('>'))
            {
            }

            return buffer;
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            buffer = _serialPort.ReadExisting();
        }
    }
}
