using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Helpers;
using EngineLineLibrary.Vehicle.Models;

namespace EngineLineLibrary.Vehicle
{
    public class DiagnosticTroubleCodeHandler : IDiagnosticTroubleCodeHandler
    {
        private readonly IObd2Device _device;

        public DiagnosticTroubleCodeHandler(IObd2Device device)
        {
            _device = device;
        }

        public List<DiagnosticTroubleCode> GetReportedDiagnosticTroubleCodes()
        {
            var command = ((int)Service.DiagnosticTroubleCodes).ToString("X");
            var response = _device.Query(command);

            var rawDiagnosticTroubleCodes = ExtractRawDiagnosticTroubleCodes(response);

            return DecodeMultipleDiagnosticTroubleCodes(rawDiagnosticTroubleCodes);
        }

        public DiagnosticTroubleCode GetFreezeFrameDiagnosticTroubleCode()
        {
            var freezeFrameDataMode = ((int)Service.FreezeFrameData).ToString("X");
            var command = freezeFrameDataMode + ((int)Pid.DtcThatCausedFreezeFrame).ToString("X");

            var response = _device.Query(command);

            var rawDiagnosticTroubleCode = response.Substring(6)
                .Replace(" ", "");

            return DecodeDiagnosticTroubleCode(rawDiagnosticTroubleCode);
        }

        public void ClearDiagnosticTroubleCodes()
        {
            var command = ((int)Service.ClearStoredValues).ToString("X");
            _device.Query(command);
        }

        private static List<string> ExtractRawDiagnosticTroubleCodes(string response)
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

        private List<DiagnosticTroubleCode> DecodeMultipleDiagnosticTroubleCodes(List<string> rawDiagnosticTroubleCodes)
        {
            var diagnosticTroubleCodes = new List<DiagnosticTroubleCode>();

            foreach (var code in rawDiagnosticTroubleCodes)
            {
                diagnosticTroubleCodes.Add( DecodeDiagnosticTroubleCode(code) );
            }

            return diagnosticTroubleCodes;
        }

        private DiagnosticTroubleCode DecodeDiagnosticTroubleCode(string code) 
        {
            var decodedCode = string.Concat(DtcDecodeData.TypeOfDiagnosticTroubleCodeLookup[code[0]], code.Substring(1));
            var system = DtcDecodeData.SystemMalfunctioningLookup[decodedCode[0]];

            var subsystem = "";
            if (decodedCode[1] == '0')
            {
                subsystem = DtcDecodeData.SubsystemMalfunctioningLookup.ContainsKey(decodedCode[2]) ? DtcDecodeData.SubsystemMalfunctioningLookup[decodedCode[2]] : "";
            }
            var description =
                DtcDecodeData.DescriptionOfDiagnosticTroubleCodeLookup.ContainsKey(decodedCode) ?
                    DtcDecodeData.DescriptionOfDiagnosticTroubleCodeLookup[decodedCode] : "Not available - check your vehicle manual or contact the manufacturer.";

            return
                new DiagnosticTroubleCode()
                {
                    Code = decodedCode,
                    System = system,
                    Subsystem = subsystem,
                    Description = description,
                };
        }
    }
}
