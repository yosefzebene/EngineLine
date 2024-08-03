using EngineLineLibrary.Connection.ExternalDependencies;
using System.IO.Ports;
using System.Text;

namespace EngineLineLibrary.Connection
{
    public class SerialConnection : IConnection
    {
        private const int DEFAULT_BAUD = 38400;

        private readonly ISerialPort _serialPort;

        public SerialConnection(ISerialPort serialPort)
        {
            _serialPort = serialPort;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;
        }

        public bool Connect(string port, int baudRate = DEFAULT_BAUD)
        {
            _serialPort.PortName = port;
            _serialPort.BaudRate = baudRate;
            _serialPort.Open();

            return _serialPort.IsOpen;
        }

        public bool Disconnect()
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();

            return !_serialPort.IsOpen;
        }

        public string SendMessage(string message)
        {
            _serialPort.WriteLine(string.Format("{0}{1}", message, "\r"));

            var buffer = ReadSerialPort();

            return buffer;
        }

        private string ReadSerialPort()
        {
            string stringBuffer = "";
            byte[] buffer = new byte[byte.MaxValue];

            Action kickoffRead = null;
            kickoffRead = delegate
                {
                    int actualLength = _serialPort.BaseStream.Read(buffer, 0, buffer.Length);

                    byte[] received = new byte[actualLength];
                    Buffer.BlockCopy(buffer, 0, received, 0, actualLength);

                    stringBuffer += Encoding.ASCII.GetString(received, 0, received.Length);

                    if (!stringBuffer.Contains('>'))
                        kickoffRead();
                };
            kickoffRead();

            return stringBuffer;
        }
    }
}
