using EngineLine.Connection.Devices;
using EngineLine.Connection.ExternalDependencies;
using System.IO.Ports;

namespace EngineLine.Connection
{
    public static class ConnectionManager
    {
        public static IObd2Device CreateSerialConnection(string port, int baudRate)
        {
            var serial = new SerialPortWrapper();
            var serialConnection = new SerialConnection(serial);
            serialConnection.Connect(port, baudRate);

            return new ElmObd2Device(serialConnection);
        }

        public static string[] GetAvailableSerialDevices()
        {
            var ports = SerialPort.GetPortNames();
            ports = ports.Where(port => port.StartsWith("COM")).ToArray();

            return ports;
        }
    }
}
