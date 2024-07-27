using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Connection.Enums;
using EngineLineLibrary.Connection.ExternalDependencies;

namespace EngineLineLibrary.Connection
{
    public class ConnectionManager
    {
        private readonly ISerialPort _serialPort;

        public string[] SupportedProtocols { get; private set; }
        public string[] ConnectionMethods { get; private set; }
        public int[] BaudRates { get; private set; }

        public ConnectionManager(ISerialPort serialPort)
        {
            _serialPort = serialPort;

            SupportedProtocols = new string[]
            {
                "Automatic",
                "SAE J1850 PMW (41.6 kbaud)",
                "SAE J1850 VPW (10.4 kbaud)",
                "ISO 9141-2 (5 baud init, 10.4 kbaud)",
                "ISO 14230 - 4 KWP(5 baud init, 10.4 kbaud",
                "ISO 14230 - 4 KWP(fast init, 10.4 kbaud)",
                "ISO 15765 - 4 CAN(11 bit ID, 500 kbaud)",
                "ISO 15765 - 4 CAN(29 bit ID, 500 kbaud)",
                "ISO 15765 - 4 CAN(11 bit ID, 250 kbaud)",
                "ISO 15765 - 4 CAN(29 bit ID, 250 kbaud)",
                "SAE J1939 CAN (29 bit ID, 250* kbaud)"
            };
            ConnectionMethods = Enum.GetNames(typeof(ConnectionMethod));
            BaudRates = new int[] { 9600, 19200, 38400, 57600, 115200 };
        }

        public IObd2Device CreateSerialConnection(string port, int baudRate, int protocol)
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
