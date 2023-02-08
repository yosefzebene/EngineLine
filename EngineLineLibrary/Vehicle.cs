using System.Collections;
using System.Globalization;
using System.Security.Cryptography;

namespace EngineLineLibrary
{
    public class Vehicle
    {
        private readonly Dictionary<char, string> dtcDict = new Dictionary<char, string>
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

        private readonly List<string> StatusCheckNames = new()
        {
            "EGR and/or VVT System",
            "Oxygen Sensor Heater",
            "Oxygen Sensor",
            "Gasoline Particulate Filter",
            "Secondary Air System",
            "Evaporative System",
            "Heated Catalyst",
            "Catalyst"
        };

        private IObdConnection _connection;

        public Vehicle(IObdConnection connection)
        {
            _connection = connection;
        }

        // 01 Mode
        public int GetRpm()
        {
            var response = _connection.Query(new Request(PID.RPM));

            var hexResponse = response.singleLineResponseToHexArray();

            return int.Parse(hexResponse[2] + hexResponse[3], NumberStyles.HexNumber) / 4;
        }

        public int GetSpeed()
        {
            var response = _connection.Query(new Request(PID.Speed));

            var hexResponse = response.singleLineResponseToHexArray();

            return int.Parse(hexResponse[2], NumberStyles.HexNumber);
        }

        public int GetTemperature()
        {
            var response = _connection.Query(new Request(PID.Temperature));

            var hexResponse = response.singleLineResponseToHexArray();

            return int.Parse(hexResponse[2], NumberStyles.HexNumber) - 40;
        }

        public decimal GetTPS()
        {
            var response = _connection.Query(new Request(PID.ThrottlePosition));

            var hexResponse = response.singleLineResponseToHexArray();

            // Formula for tps: x*100/255
            var tps = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber) * 100 / 255;

            return decimal.Round(tps, 1);
        }

        public decimal GetMAF()
        {
            var response = _connection.Query(new Request(PID.MassAirFlow));

            var hexResponse = response.singleLineResponseToHexArray();

            // Formula for MAF: ((A*256)+B)/4
            var a = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber);
            var b = (decimal)int.Parse(hexResponse[3], NumberStyles.HexNumber);

            var massAirFlow = ((a * 256) + b) / 100;

            return decimal.Round(massAirFlow, 1);
        }

        public decimal GetShortTermFuelTrimB1()
        {
            var response = _connection.Query(new Request(PID.ShortTermFuelTrimB1));

            return FuelTrimCalculation(response);
        }

        public decimal GetShortTermFuelTrimB2()
        {
            var response = _connection.Query(new Request(PID.ShortTermFuelTrimB2));

            return FuelTrimCalculation(response);
        }

        public decimal GetLongTermFuelTrimB1()
        {
            var response = _connection.Query(new Request(PID.LongTermFuelTrimB1));

            return FuelTrimCalculation(response);
        }

        public decimal GetLongTermFuelTrimB2()
        {
            var response = _connection.Query(new Request(PID.LongTermFuelTrimB2));

            return FuelTrimCalculation(response);
        }

        public decimal GetOxygenSensor1B1()
        {
            var response = _connection.Query(new Request(PID.OxygenSensor1B1));

            var hexResponse = response.singleLineResponseToHexArray();
            var voltage = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber) / 200;

            return decimal.Round(voltage, 3);
        }

        public decimal GetOxygenSensor2B1()
        {
            var response = _connection.Query(new Request(PID.OxygenSensor2B1));

            var hexResponse = response.singleLineResponseToHexArray();
            var voltage = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber) / 200;

            return decimal.Round(voltage, 3);
        }

        public decimal GetOxygenSensor1B2()
        {
            var response = _connection.Query(new Request(PID.OxygenSensor1B2));

            var hexResponse = response.singleLineResponseToHexArray();
            var voltage = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber) / 200;

            return decimal.Round(voltage, 3);
        }

        public decimal GetOxygenSensor2B2()
        {
            var response = _connection.Query(new Request(PID.OxygenSensor2B2));

            var hexResponse = response.singleLineResponseToHexArray();
            var voltage = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber) / 200;

            return decimal.Round(voltage, 3);
        }

        public List<ReadinessMonitorStatus> GetMonitorStatuses()
        {
            List<ReadinessMonitorStatus> statusList = new();

            var response = _connection.Query(new Request(PID.MonitorSinceDtcCleared));
            var statusHexResponse = response.singleLineResponseToHexArray();

            response = _connection.Query(new Request(PID.MonitorCurrentDriveCycle));
            var currentCycleHexResponse = response.singleLineResponseToHexArray();

            var bBoolArray = BinaryToBoolArray(
                Convert.ToString(
                    byte.Parse(statusHexResponse[3], NumberStyles.HexNumber),
                    2).PadLeft(8, '0')
                );

            var bBoolArrayCurrentCycle = BinaryToBoolArray(
                Convert.ToString(
                    byte.Parse(currentCycleHexResponse[3], NumberStyles.HexNumber),
                    2).PadLeft(8, '0')
                );

            // If this bit is true it is a diesel engine so return an empty list
            if (bBoolArray[4])
            {
                return statusList;
            }

            statusList.Add(
                new ReadinessMonitorStatus()
                {
                    Name = "Components",
                    Available = bBoolArray[5],
                    Incomplete = bBoolArray[1],
                    IncompleteCurrentDriveCycle = bBoolArrayCurrentCycle[1]
                });

            statusList.Add(
                new ReadinessMonitorStatus()
                {
                    Name = "Fuel System",
                    Available = bBoolArray[6],
                    Incomplete = bBoolArray[2],
                    IncompleteCurrentDriveCycle = bBoolArrayCurrentCycle[2]
                });

            statusList.Add(
                new ReadinessMonitorStatus()
                {
                    Name = "Misfire",
                    Available = bBoolArray[7],
                    Incomplete = bBoolArray[3],
                    IncompleteCurrentDriveCycle = bBoolArrayCurrentCycle[3]
                });

            // Get C and D bool arrays
            // C is availability
            // D is completeness
            var cBoolArray = BinaryToBoolArray(
                Convert.ToString(
                    byte.Parse(statusHexResponse[4], NumberStyles.HexNumber),
                    2).PadLeft(8, '0')
                );

            var dBoolArray = BinaryToBoolArray(
                Convert.ToString(
                    byte.Parse(statusHexResponse[5], NumberStyles.HexNumber),
                    2).PadLeft(8, '0')
                );

            var dBoolArrayCurrentCycle = BinaryToBoolArray(
                Convert.ToString(
                    byte.Parse(currentCycleHexResponse[5], NumberStyles.HexNumber),
                    2).PadLeft(8, '0')
                );

            for (int i = 0; i < StatusCheckNames.Count; i++)
            {
                statusList.Add(
                    new ReadinessMonitorStatus()
                    {
                        Name = StatusCheckNames[i],
                        Available = cBoolArray[i],
                        Incomplete = dBoolArray[i],
                        IncompleteCurrentDriveCycle = dBoolArrayCurrentCycle[i]
                    });
            }

            return statusList;
        }

        // 03 mode
        public List<string> GetDiagnosticTroubleCodes()
        {
            List<string> dtcList = new List<string>();  // The final list of trouble codes to be returned
            List<string> dtcRaw = new List<string>();

            var response = _connection.Query(new Request(PID.DiagnosticTroubleCodes));

            var responseString = response.ResponseString.Trim(new char[] { '>', '\r', '\n' });

            // NOTE: This condition should be handled in the error handler
            if (responseString != "NO DATA")
            {
                var dtcLines = responseString.Split("\r\n");

                foreach (var dtcLine in dtcLines)
                {
                    // each line of engine code data returns 3 engine codes
                    var allDtcs = dtcLine.Substring(3);

                    // Get all the engine codes
                    dtcRaw.Add(allDtcs.Remove(5).Replace(" ", ""));
                    allDtcs = allDtcs.Substring(6);

                    dtcRaw.Add(allDtcs.Remove(5).Replace(" ", ""));
                    allDtcs = allDtcs.Substring(6);

                    dtcRaw.Add(allDtcs.Remove(5).Replace(" ", ""));
                }

                dtcRaw.ForEach(dtc =>
                {
                    if (dtc != "0000")
                    {
                        var dtcChars = dtc.ToCharArray();
                        string dtcString;

                        // Check for the first character of the engine code in the engine code dictionary
                        if (dtcDict.ContainsKey(dtcChars[0]))
                            dtcString = dtcDict[dtcChars[0]] + dtc.Substring(1);
                        else
                            throw new ApplicationException();

                        dtcList.Add(dtcString);
                    }
                });
            }

            return dtcList;
        }

        // 04 mode
        public bool ResetCodes()
        {
            // Send the command
            _connection.Query(new Request(PID.ClearDiagnosticTroubleCodes));

            return true;
        }

        // Fuel trim calculation
        private decimal FuelTrimCalculation(Response response)
        {
            var hexResponse = response.singleLineResponseToHexArray();

            var a = (decimal)int.Parse(hexResponse[2], NumberStyles.HexNumber);

            return decimal.Round((a * 1.28m) - 100, 1);
        }

        private bool[] BinaryToBoolArray(string BinaryString)
        {
            return BinaryString.Select(c => c == '1').ToArray();
        }

        public void Disconnect()
        {
            _connection.CloseConnection();
        }
    }
}
