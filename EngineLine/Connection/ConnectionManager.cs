using EngineLine.Connection.Devices;
using EngineLine.Connection.ExternalDependencies;

namespace EngineLine.Connection
{
    public class ConnectionManager
    {
        private readonly ISerialPort _serialPort;

        public ConnectionManager(ISerialPort serialPort)
        { 
            _serialPort = serialPort;
        }

        public IObd2Device CreateSerialConnection(string port, int baudRate)
        {
            var serialConnection = new SerialConnection(_serialPort);
            serialConnection.Connect(port, baudRate);

            return new ElmObd2Device(serialConnection);
        }

        public string[] GetAvailableSerialDevices()
        {
            var ports = _serialPort.GetPortNames();
            ports = ports.Where(port => port.StartsWith("COM")).ToArray();

            return ports;
        }
    }
}
