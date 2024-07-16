using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Vehicle.Helpers;
using EngineLineLibrary.Vehicle.Models;
using System.Text.Json;

namespace EngineLineLibrary.Vehicle
{
    public class DiagnosticTroubleCodeHandler : IDiagnosticTroubleCodeHandler
    {
        private readonly IObd2Device _device;

        private readonly Dictionary<char, string> TypeOfDiagnosticTroubleCodeLookup = new()
        {
            { '0', "P0" },
            { '1', "P1" },
            { '2', "P2" },
            { '3', "P3" },
            { '4', "C0" },
            { '5', "C1" },
            { '6', "C2" },
            { '7', "C3" },
            { '8', "B0" },
            { '9', "B1" },
            { 'A', "B2" },
            { 'B', "B3" },
            { 'C', "U0" },
            { 'D', "U1" },
            { 'E', "U2" },
            { 'F', "U3" },
        };

        private readonly Dictionary<char, string> SystemMalfunctioningLookup = new()
        {
            { 'P', "Powertrain" },
            { 'C', "Chassis" },
            { 'B', "Body" },
            { 'U', "Network" }
        };

        private readonly Dictionary<char, string> SubsystemMalfunctioningLookup = new()
        {
            { '0', "Fuel and air metering and auxiliary emission controls" },
            { '1', "Fuel and air metering" },
            { '2', "Fuel and air metering injection system" },
            { '3', "Ignition systems" },
            { '4', "Emissions system" },
            { '5', "Vehicle speed controls and idle control system" },
            { '6', "Computer output circuit" },
            { '7', "Transmission" },
            { '8', "Transmission" },
        };

        private readonly Dictionary<string, string> DescriptionOfDiagnosticTroubleCodeLookup = new() {};

        public DiagnosticTroubleCodeHandler(IObd2Device device)
        {
            _device = device;

            try
            {
                var dtcDescriptionsJson = File.ReadAllText("Resources\\DiagnosticTroubleCodeDescriptions.json");
                DescriptionOfDiagnosticTroubleCodeLookup = JsonSerializer.Deserialize<Dictionary<string, string>>(dtcDescriptionsJson);
            }
            catch (FileNotFoundException)
            {
                // log
            }
        }

        public List<DiagnosticTroubleCode> GetReportedDiagnosticTroubleCodes()
        {
            var command = "03";
            var response = _device.Query(command);

            var rawDiagnosticTroubleCodes = ExtractRawDiagnosticTroubleCodes(response);

            return DecodeDiagnosticTroubleCodes(rawDiagnosticTroubleCodes);
        }

        private List<string> ExtractRawDiagnosticTroubleCodes(string response)
        {
            var multiLineHexArray = ResponseHelper.MultiLineResponseToHexArray(response);

            var rawDiagnosticTroubleCodes = new List<string>();
            foreach (var line in multiLineHexArray)
            {
                var hexArray = line.Skip(1).ToArray();

                rawDiagnosticTroubleCodes.Add(hexArray[0] + hexArray[1]);
                rawDiagnosticTroubleCodes.Add(hexArray[2] + hexArray[3]);
                rawDiagnosticTroubleCodes.Add(hexArray[4] + hexArray[5]);
            }

            return rawDiagnosticTroubleCodes.Where(code => !code.Equals("0000")).ToList();
        }

        private List<DiagnosticTroubleCode> DecodeDiagnosticTroubleCodes(List<string> rawDiagnosticTroubleCodes)
        {
            var diagnosticTroubleCodes = new List<DiagnosticTroubleCode>();

            foreach (var code in rawDiagnosticTroubleCodes)
            {
                var decodedCode = string.Concat(TypeOfDiagnosticTroubleCodeLookup[code[0]], code.Substring(1));
                var system = SystemMalfunctioningLookup[decodedCode[0]];

                var subsystem = "";
                if (decodedCode[1] == '0')
                {
                    subsystem = SubsystemMalfunctioningLookup.ContainsKey(decodedCode[2]) ? SubsystemMalfunctioningLookup[decodedCode[2]] : "";
                }
                var description =
                    DescriptionOfDiagnosticTroubleCodeLookup.ContainsKey(decodedCode) ?
                        DescriptionOfDiagnosticTroubleCodeLookup[decodedCode] : "Not available - check your vehicle manual or contact the manufacturer.";

                diagnosticTroubleCodes.Add(new DiagnosticTroubleCode()
                {
                    Code = decodedCode,
                    System = system,
                    Subsystem = subsystem,
                    Description = description,
                });
            }

            return diagnosticTroubleCodes;
        }

        public void ClearDiagnosticTroubleCodes()
        {
            var command = "04";
            _device.Query(command);
        }
    }
}
