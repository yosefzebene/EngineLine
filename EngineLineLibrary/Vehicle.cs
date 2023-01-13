using System.Globalization;

namespace EngineLineLibrary
{
    public class Vehicle
    {
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

        private IObdConnection _connection;

        public Vehicle(IObdConnection connection)
        {
            _connection = connection;
        }

        // 01 Mode
        public int ReadRpm()
        {
            var response = _connection.Query(new Request("010c"));

            var hexResponse = response.singleLineResponseToHexArray();

            return int.Parse(hexResponse[2] + hexResponse[3], NumberStyles.HexNumber) / 4;
        }

        public int ReadSpeed()
        {
            var response = _connection.Query(new Request("010D"));

            var hexResponse = response.singleLineResponseToHexArray();

            return int.Parse(hexResponse[2], NumberStyles.HexNumber);
        }

        public int ReadTemperature()
        {
            var response = _connection.Query(new Request("0105"));

            var hexResponse = response.singleLineResponseToHexArray();

            return int.Parse(hexResponse[2], NumberStyles.HexNumber) - 40;
        }

        public decimal ReadTPS()
        {
            var response = _connection.Query(new Request("0111"));

            var hexResponse = response.singleLineResponseToHexArray();

            // Formula for tps: x*100/255
            var tps = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber) * 100 / 255;

            return decimal.Round(tps, 1);
        }

        public decimal ReadMAF()
        {
            var response = _connection.Query(new Request("0110"));

            var hexResponse = response.singleLineResponseToHexArray();

            // Formula for MAF: ((A*256)+B)/4
            var a = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber);
            var b = (decimal)int.Parse(hexResponse[3], NumberStyles.HexNumber);

            var massAirFlow = ((a * 256) + b) / 100;

            return decimal.Round(massAirFlow, 1);
        }

        public decimal ShortTermFuelTrimB1()
        {
            var response = _connection.Query(new Request("0106"));

            return FuelTrimCalculation(response);
        }

        public decimal ShortTermFuelTrimB2()
        {
            var response = _connection.Query(new Request("0108"));

            return FuelTrimCalculation(response);
        }

        public decimal LongTermFuelTrimB1()
        {
            var response = _connection.Query(new Request("0108"));

            return FuelTrimCalculation(response);
        }

        public decimal LongTermFuelTrimB2()
        {
            var response = _connection.Query(new Request("0109"));

            return FuelTrimCalculation(response);
        }

        // 03 mode
        public List<string> ReadEngineCodes()
        {
            List<string> engineCodesRaw = new List<string>();
            List<string> engineCodes = new List<string>();

            var response = _connection.Query(new Request("03"));

            var responseString = response.ResponseString.Trim(new char[] { '>', '\r', '\n' });

            // NOTE: This condition should be handled in the error handler
            if (responseString != "NO DATA")
            {
                var engineCodeLines = responseString.Split("\r\n");

                foreach (var engineCodeLine in engineCodeLines)
                {
                    // each line of engine code data returns 3 engine codes
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
            _connection.Query(new Request("04"));

            return true;
        }

        // Fuel trim calculation
        private decimal FuelTrimCalculation(Response response)
        {
            var hexResponse = response.singleLineResponseToHexArray();

            var a = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber);

            return decimal.Round((a * 1.28m) - 100, 1);
        }
    }
}
