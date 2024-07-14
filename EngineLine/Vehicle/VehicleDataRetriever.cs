using EngineLine.Connection.Devices;
using EngineLine.Exceptions;
using EngineLine.Utility;
using EngineLine.Vehicle.Enums;

namespace EngineLine.Vehicle
{
    public class VehicleDataRetriever
    {
        private readonly IObd2Device _device;
        private readonly Dictionary<Pid, bool> PidSupport = new();

        public VehicleDataRetriever(IObd2Device device)
        {
            _device = device;

            var pids = Enum.GetValues(typeof(Pid)).Cast<Pid>().ToArray();
            foreach (var pid in pids)
            {
                PidSupport.Add(pid, false);
            }
        }

        public Pid[] GetSupportedCommands()
        {
            var realTimeDataMode = "01";

            try
            {
                for (var offset = 0; offset < Enum.GetValues(typeof(Pid)).Length; offset += 32)
                {
                    var pidInHex = (0 + offset).ToString("X");
                    var command = realTimeDataMode + pidInHex;
                    var response = _device.Query(command);

                    var hexArray = ResponseHelper.SingleLineResponseToHexArray(response).Skip(2).ToArray();

                    var boolArray = ResponseHelper.HexToBoolArray(hexArray);

                    for (var i = 0; i < boolArray.Length; i++)
                    {
                        if (boolArray[i])
                        {
                            PidSupport[(Pid)i + 1 + offset] = boolArray[i];
                        }
                    }
                }
            }
            catch (InvalidCommandReceivedException e)
            {
                //Log
            }

            return PidSupport.Where(kv => kv.Value == true).Select(kv => kv.Key).ToArray();
        }

        public decimal GetVehicleData(Pid pid)
        {
            var realTimeDataMode = "01";

            var command = realTimeDataMode + ((int)pid).ToString("X");
            var response = _device.Query(command);

            var hexArray = ResponseHelper.SingleLineResponseToHexArray(response).Skip(2).ToArray();

            return PidCalculation.CalculateBasedOnPid(pid, hexArray);
        }
    }
}
