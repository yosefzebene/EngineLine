namespace EngineLineLibrary
{
    public class Request
    {
        public string Command { get; private set; }

        public Request(PID command)
        {
            Command = command.ToCommand();
        }

        public Request(string command)
        {
            Command = command;
        }

        public override string ToString()
        {
            return Command;
        }
    }

    public enum PID
    {
        RPM,
        Speed,
        Temperature,
        ThrottlePosition,
        MassAirFlow,
        ShortTermFuelTrimB1,
        ShortTermFuelTrimB2,
        LongTermFuelTrimB1,
        LongTermFuelTrimB2,
        DiagnosticTroubleCodes,
        ClearDiagnosticTroubleCodes
    }

    public static class PIDExtensions
    {
        public static string ToCommand(this PID pid)
        {
            switch(pid)
            {
                case PID.RPM:
                    return "010c";
                case PID.Speed:
                    return "010D";
                case PID.Temperature:
                    return "0105";
                case PID.ThrottlePosition:
                    return "0111";
                case PID.MassAirFlow:
                    return "0110";
                case PID.ShortTermFuelTrimB1:
                    return "0106";
                case PID.ShortTermFuelTrimB2:
                    return "0108";
                case PID.LongTermFuelTrimB1:
                    return "0107";
                case PID.LongTermFuelTrimB2:
                    return "0109";
                case PID.DiagnosticTroubleCodes:
                    return "03";
                case PID.ClearDiagnosticTroubleCodes:
                    return "04";
                default:
                    return "0100";
            }
        }
    }
}
