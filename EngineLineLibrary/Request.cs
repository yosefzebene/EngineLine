namespace EngineLineLibrary
{
    public class Request
    {
        public string Command { get; private set; }

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
                default:
                    return "0100";
            }
        }
    }
}
