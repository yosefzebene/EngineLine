using EngineLine.Connection.ExternalDependencies;
using System.IO.Ports;
using System.Text;

namespace EngineLine.Connection
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
            try
            {
                _serialPort.PortName = port;
                _serialPort.BaudRate = baudRate;
                _serialPort.Open();
            }
            catch
            {
                
            }

            return _serialPort.IsOpen;
        }

        public bool Disconnect()
        {
            try
            {
                _serialPort.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool GetConnectionStatus()
        {
            return _serialPort.IsOpen;
        }

        public string SendMessage(string message)
        {
            buffer = "";

            try
            {
                _serialPort.WriteLine(String.Format("{0}{1}", message, "\r"));
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
