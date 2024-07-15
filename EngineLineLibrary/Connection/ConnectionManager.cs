using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Connection.ExternalDependencies;

namespace EngineLineLibrary.Connection
{
    public class ConnectionManager
    {
        private readonly ISerialPort _serialPort;

        public ConnectionManager(ISerialPort serialPort)
        {
            _serialPort = serialPort;
        }

        public IObd2Device CreateSerialConnection(string port, int baudRate, string protocol)
        {
            var serialConnection = new SerialConnection(_serialPort);
            serialConnection.Connect(port, baudRate);

            return new ElmObd2Device(serialConnection, protocol);
        }

        public string[] GetAvailableSerialDevices()
        {
            var ports = _serialPort.GetPortNames();
            ports = ports.Where(port => port.StartsWith("COM")).ToArray();

            return ports;
        }
    }
}
