using EngineLine.Connection.ExternalDependencies;
using System.IO.Ports;
using System.Text;

namespace EngineLine.Connection
{
    public class SerialConnection : IConnection
    {
        private const int DEFAULT_BAUD = 38400;

        private readonly ISerialPort _serialPort;
        private bool isConnected = false;
        private string buffer = "";

        public SerialConnection(ISerialPort serialPort, string port, int baudRate = DEFAULT_BAUD)
        {
            _serialPort = serialPort;
            _serialPort.PortName = port;
            _serialPort.BaudRate = baudRate;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);
        }

        public bool Connect()
        {
            try
            {
                _serialPort.Open();
                isConnected = true;
            }
            catch
            {
                isConnected = false;
            }

            return isConnected;
        }

        public bool Disconnect()
        {
            try
            {
                _serialPort.Close();
                isConnected = false;
            } 
            catch
            { 
                return false; 
            }

            return true;
        }

        public bool GetConnectionStatus()
        {
            return isConnected;
        }

        public string SendMessage(string message)
        {
            buffer = "";

            try
            {
                _serialPort.WriteLine(message);
            }
            catch
            {

            }

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
