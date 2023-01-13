using System.Globalization;
using System.IO.Ports;
using System.Text;

namespace EngineLineLibrary
{
    public class NoDataFoundException : Exception
    {
        public NoDataFoundException(){}
    }

    public class ObdConnection : IObdConnection
    {
        private const int DEFAULT_BAUD = 38400;

        private SerialPort _serialPort;
        private StringBuilder buffer = new StringBuilder();  // Contains the response to the last command sent

        public ObdConnection(string port, string protocol, int baudRate = DEFAULT_BAUD)
        {
            _serialPort = new SerialPort();

            _serialPort.PortName = port;
            _serialPort.BaudRate = baudRate;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);

            _serialPort.Open();

            InitalizeConnection(protocol);
        }

        private void InitalizeConnection(string protocol)
        {
            var init_commands = new List<string>() { "ATD", "ATE0", protocol, "0100" };

            init_commands.ForEach(command =>
            {
                Query(new Request(command));
            });
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            buffer.Append(_serialPort.ReadExisting());
        }

        public Response Query(Request command)
        {
            // Clear the buffer every time a new command is sent
            buffer.Clear();

            _serialPort.WriteLine(String.Format("{0}{1}", command, "\r\n"));

            //Wait to make sure the buffer is updated with the response data from the command
            while (!buffer.ToString().Contains('>'))
            {
                Thread.Sleep(30);
            }

            //Call a function to check the result for errors
            CheckForErrorsInResponse();

            return new(buffer.ToString());
        }

        // TODO: Move this error handling to the response object
        private void CheckForErrorsInResponse()
        {
            var response = buffer.ToString().Trim(new char[] { '>', '\r', '\n' });
            // Any Connection error should close the serial connection
            if (response == "SEARCHING...\r\nUNABLE TO CONNECT" || response == "BUS ERROR")
            {
                CloseConnection();
                throw new Exception("Bus Connection Error");
            }

            if (response == "NO DATA")
            {
                throw new NoDataFoundException();
            }
        }

        public void CloseConnection()
        {
            _serialPort.Close();
        }
    }
}
