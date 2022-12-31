using System.Globalization;
using System.IO.Ports;
using System.Text;

namespace EngineLineLibrary
{
    public class ObdConnection : IObdConnection
    {
        private const int DEFAULT_BAUD = 38400;
        private readonly Dictionary<char, string> engineCodeDict = new Dictionary<char, string>
        {
            {'0', "P0" },
            {'1', "P1" },
            {'2', "P2" },
            {'3', "P3" },
            {'4', "C0" },
            {'5', "C1" },
            {'6', "C2" },
            {'7', "C3" },
            {'8', "B0" },
            {'9', "B1" },
            {'A', "B2" },
            {'B', "B3" },
            {'C', "U0" },
            {'D', "U1" },
            {'E', "U2" },
            {'F', "U3" }
        };

        //{
        //    { "Automatic", "AT SP 0" },
        //    { "SAE J1850 PMW (41.6 kbaud)", "AT SP 1" },
        //    { "SAE J1850 VPW (10.4 kbaud)", "AT SP 2" },
        //    { "ISO 9141-2 (5 baud init, 10.4 kbaud)", "AT SP 3" },
        //    { "ISO 14230 - 4 KWP(5 baud init, 10.4 kbaud)", "AT SP 4" },
        //    { "ISO 14230 - 4 KWP(fast init, 10.4 kbaud)", "AT SP 5" },
        //    { "ISO 15765 - 4 CAN(11 bit ID, 500 kbaud)", "AT SP 6" },
        //    { "ISO 15765 - 4 CAN(29 bit ID, 500 kbaud)", "AT SP 7" }
        //};

        public enum CommandType
        {
            ConnectionCommand,
            EngineInfoCommand
        }

        private SerialPort _serialPort;
        private StringBuilder buffer = new StringBuilder();  // Contains the response to the last command sent

        public ObdConnection(string port, int baudRate = DEFAULT_BAUD, string protocol = "AT SP 0")
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

            init_commands.ForEach(command => WriteToSerialAndWaitForResponse(command, CommandType.ConnectionCommand));
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            buffer.Append(_serialPort.ReadExisting());
        }

        public void WriteToSerialAndWaitForResponse(string command, CommandType commandType /* Pass the type of command that was sent */)
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
            CheckForErrorsInResponse(commandType);
        }

        // NOTE: Add error handling
        private void CheckForErrorsInResponse(CommandType commandType)
        {
            // throw descriptive errors based on command type
        }

        // 01 Mode
        public int ReadRpm()
        {
            // Send the command
            var command = "010c";
            WriteToSerialAndWaitForResponse(command, CommandType.EngineInfoCommand);

            var hexResponse = singleLineResponseToHexArray();

            return int.Parse(hexResponse[2] + hexResponse[3], NumberStyles.HexNumber) / 4;
        }

        public int ReadSpeed()
        {
            var command = "010D";
            WriteToSerialAndWaitForResponse(command, CommandType.EngineInfoCommand);

            var hexResponse = singleLineResponseToHexArray();

            return int.Parse(hexResponse[2], NumberStyles.HexNumber);
        }

        public int ReadTemperature()
        {
            var command = "0105";
            WriteToSerialAndWaitForResponse(command, CommandType.EngineInfoCommand);

            var hexResponse = singleLineResponseToHexArray();

            return int.Parse(hexResponse[2], NumberStyles.HexNumber) - 40;
        }

        public decimal ReadTPS()
        {
            var command = "0111";
            WriteToSerialAndWaitForResponse(command, CommandType.EngineInfoCommand);

            var hexResponse = singleLineResponseToHexArray();

            // Formula for tps: x*100/255
            var tps = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber) * 100 / 255;

            return decimal.Round(tps, 1);
        }

        public decimal ReadMAF()
        {
            var command = "0110";
            WriteToSerialAndWaitForResponse(command, CommandType.EngineInfoCommand);

            var hexResponse = singleLineResponseToHexArray();

            // Formula for MAF: ((A*256)+B)/4
            var a = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber);
            var b = (decimal)int.Parse(hexResponse[3], NumberStyles.HexNumber);

            var massAirFlow = ((a * 256) + b) / 100;

            return decimal.Round(massAirFlow, 1);
        }

        // 03 mode
        public List<string> ReadEngineCodes()
        {
            List<string> engineCodesRaw = new List<string>();
            List<string> engineCodes = new List<string>();

            var command = "03";
            WriteToSerialAndWaitForResponse(command, CommandType.EngineInfoCommand);

            var response = buffer.ToString().Trim(new char[] { '>', '\r', '\n' });

            // NOTE: This condition should be handled in the error handler
            if (response != "NO DATA")
            {
                var engineCodeLines = response.Split("\r\n");

                foreach (var engineCodeLine in engineCodeLines)
                {
                    // each line of engie code data returns 3 engine codes
                    var allEngineCode = engineCodeLine.Substring(3);

                    // Get all the engine codes
                    engineCodesRaw.Add(allEngineCode.Remove(5).Replace(" ", ""));
                    allEngineCode = allEngineCode.Substring(6);

                    engineCodesRaw.Add(allEngineCode.Remove(5).Replace(" ", ""));
                    allEngineCode = allEngineCode.Substring(6);

                    engineCodesRaw.Add(allEngineCode.Remove(5).Replace(" ", ""));
                }

                engineCodesRaw.ForEach(engineCode =>
                {
                    if (engineCode != "0000")
                    {
                        var engineCodeChars = engineCode.ToCharArray();
                        string engineCodeString;

                        // Check for the first character of the engine code in the engine code dictionary
                        if (engineCodeDict.ContainsKey(engineCodeChars[0]))
                            engineCodeString = engineCodeDict[engineCodeChars[0]] + engineCode.Substring(1);
                        else
                            throw new ApplicationException();

                        engineCodes.Add(engineCodeString);
                    }
                });
            }

            return engineCodes;
        }

        // 04 mode
        public bool ResetCodes()
        {
            // Send the command
            var command = "04";
            WriteToSerialAndWaitForResponse(command, CommandType.EngineInfoCommand);

            return true;
        }

        private string[] singleLineResponseToHexArray()
        {
            var response = buffer.ToString().Trim(new char[] { '>', '\r', '\n' });

            return response.Split(' ');
        }
    }
}
