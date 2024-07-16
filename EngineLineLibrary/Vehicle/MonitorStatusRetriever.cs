using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Exceptions;
using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Helpers;
using EngineLineLibrary.Vehicle.Models;
using System.Globalization;

namespace EngineLineLibrary.Vehicle
{
    public class MonitorStatusRetriever : IMonitorStatusRetriever
    {
        private readonly IObd2Device _device;

        private readonly List<string> SparkIgnitionReadinessCheckNames = new()
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

        private readonly List<string> CompressionIgnitionReadinessCheckNames = new()
        {
            "EGR and/or VVT System",
            "PM filter monitoring",
            "Exhaust Gas Sensor",
            "Unknown",
            "Boost Pressure",
            "Unknown",
            "NOx/SCR Monitor",
            "NMHC Catalyst"
        };

        public MonitorStatusRetriever(IObd2Device device)
        {
            _device = device;
        }

        public MonitorStatus GetMonitorStatus()
        {
            var realTimeDataMode = "01";

            var command = realTimeDataMode + ((int)Pid.MonitorStatusSinceDtcCleared).ToString("X");
            var response = _device.Query(command);

            var hexArray = ResponseHelper.SingleLineResponseToHexArray(response).Skip(2).ToArray();

            return DecodeMonitorStatus(hexArray);
        }

        private MonitorStatus DecodeMonitorStatus(string[] hexArray)
        {
            var monitorStatus = new MonitorStatus()
            {
                ReadinessChecks = new()
            };

            if (hexArray[0] != "00")
            {
                monitorStatus.CheckEngineLightOn = true;
                monitorStatus.NumberOfDtcs = int.Parse(hexArray[0], NumberStyles.HexNumber) - 128;
            }

            DecodeSecondByte(monitorStatus, hexArray[1]);

            DecodeLastTwoBytes(monitorStatus, hexArray[2], hexArray[3]);

            return monitorStatus;
        }

        private void DecodeSecondByte(MonitorStatus monitorStatus, string secondByte)
        {
            var secondByteBoolArray = ResponseHelper.HexToBoolArray(new[] { secondByte });

            if (secondByteBoolArray[4])
                monitorStatus.EngineType = "Compression ignition";
            else
                monitorStatus.EngineType = "Spark ignition";

            monitorStatus.ReadinessChecks.Add(
                new ReadinessCheck()
                {
                    Name = "Components",
                    Available = secondByteBoolArray[5],
                    Incomplete = secondByteBoolArray[1]
                });

            monitorStatus.ReadinessChecks.Add(
                new ReadinessCheck()
                {
                    Name = "Fuel System",
                    Available = secondByteBoolArray[6],
                    Incomplete = secondByteBoolArray[2]
                });

            monitorStatus.ReadinessChecks.Add(
                new ReadinessCheck()
                {
                    Name = "Misfire",
                    Available = secondByteBoolArray[7],
                    Incomplete = secondByteBoolArray[3]
                });
        }

        private void DecodeLastTwoBytes(MonitorStatus monitorStatus, string thirdByte, string fourthByte)
        {
            var thirdByteBoolArray = ResponseHelper.HexToBoolArray(new[] { thirdByte });
            var fourthByteBoolArray = ResponseHelper.HexToBoolArray(new[] { fourthByte });

            for (int i = 0; i < thirdByteBoolArray.Length; i++)
            {
                monitorStatus.ReadinessChecks.Add(
                    new ReadinessCheck()
                    {
                        Name = monitorStatus.EngineType == "Compression ignition" ? CompressionIgnitionReadinessCheckNames[i] : SparkIgnitionReadinessCheckNames[i],
                        Available = thirdByteBoolArray[i],
                        Incomplete = fourthByteBoolArray[i]
                    });
            }
        }
    }
}
