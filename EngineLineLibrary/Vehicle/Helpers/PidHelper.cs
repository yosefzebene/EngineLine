using EngineLineLibrary.Exceptions;
using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Models;
using System.Globalization;

namespace EngineLineLibrary.Vehicle.Helpers
{
    public static class PidHelper
    {
        public static PidData CalculateBasedOnPid(Pid pid, string[] hexArray)
        {
            var calculationResult = pid switch
            {
                Pid.CalculatedEngineLoad => new PidData() 
                {
                    PidName = pid.ToString(),
                    Result = CalculatedEngineLoadCalculation(hexArray),
                    Unit = "%"
                },
                Pid.EngineCoolantTemperature => new PidData() 
                {
                    PidName = pid.ToString(),
                    Result = EngineCoolantTemperatureCalculation(hexArray),
                    Unit = "°C"
                },
                Pid.ShortTermFuelTrimBank1 => new PidData() 
                {
                    PidName = pid.ToString(),
                    Result = FuelTrimCalculation(hexArray),
                    Unit = "%"
                },
                Pid.LongTermFuelTrimBank1 => new PidData() 
                {
                    PidName = pid.ToString(),
                    Result = FuelTrimCalculation(hexArray),
                    Unit = "%"
                },
                Pid.ShortTermFuelTrimBank2 => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = FuelTrimCalculation(hexArray),
                    Unit = "%"
                },
                Pid.LongTermFuelTrimBank2 => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = FuelTrimCalculation(hexArray),
                    Unit = "%"
                },
                Pid.FuelPressure => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = FuelPressureCalculation(hexArray),
                    Unit = "kPa"
                },
                Pid.IntakeManifoldAbsolutePressure => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = IntakeManifoldAbsolutePressureCalculation(hexArray),
                    Unit = "kPa"
                },
                Pid.EngineSpeed => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = EngineSpeedCalculation(hexArray),
                    Unit = "rpm"
                },
                Pid.VehicleSpeed => new PidData() 
                {
                    PidName = pid.ToString(),
                    Result = VehicleSpeedCalculation(hexArray),
                    Unit = "km/h"
                },
                Pid.TimingAdvance => new PidData() 
                {
                    PidName = pid.ToString(),
                    Result = TimingAdvanceCalculation(hexArray),
                    Unit = "°"
                },
                Pid.IntakeAirTemperature => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = IntakeAirTemperatureCalculation(hexArray),
                    Unit = "°C"
                },
                Pid.MassAirFlowSensor => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = MassAirFlowSensorCalculation(hexArray),
                    Unit = "g/s"
                },
                Pid.ThrottlePosition => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = ThrottlePositionCalculation(hexArray),
                    Unit = "%"
                },
                Pid.OxygenSensor1Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = OxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.OxygenSensor2Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = OxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.OxygenSensor3Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = OxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.OxygenSensor4Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = OxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.OxygenSensor5Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = OxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.OxygenSensor6Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = OxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.OxygenSensor7Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = OxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.OxygenSensor8Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = OxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.RunTimeSinceStart => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = RunTimeSinceStartCalculation(hexArray),
                    Unit = "s"
                },
                Pid.DistanceTravelSinceCheckEngineLightOn => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = DistanceTravelSinceCheckEngineLightOnCalculation(hexArray),
                    Unit = "km"
                },
                Pid.FuelRailPressure => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = FuelRailPressureCalculation(hexArray),
                    Unit = "kPa"
                },
                Pid.FuelRailGaugePressure => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = FuelRailGaugePressureCalculation(hexArray),
                    Unit = "kPa"
                },
                Pid.WideBandOxygenSensor1Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.WideBandOxygenSensor2Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.WideBandOxygenSensor3Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.WideBandOxygenSensor4Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.WideBandOxygenSensor5Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.WideBandOxygenSensor6Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.WideBandOxygenSensor7Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.WideBandOxygenSensor8Voltage => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorVoltageCalculation(hexArray),
                    Unit = "V"
                },
                Pid.CommandedEgr => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = CommandedEgrCalculation(hexArray),
                    Unit = "%"
                },
                Pid.FuelTankLevel => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = FuelTankLevelCalculation(hexArray),
                    Unit = "%"
                },
                Pid.WarmupsSinceCodesCleared => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WarmupsSinceCodesClearedCalculation(hexArray),
                    Unit = ""
                },
                Pid.DistanceTraveledSinceCodesCleared => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = DistanceTraveledSinceCodesClearedCalculation(hexArray),
                    Unit = "km"
                },
                Pid.EvapSystemVaporPressure => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = EvapSystemVaporPressureCalculation(hexArray),
                    Unit = "Pa"
                },
                Pid.AbsoluteBarometricPressure => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = AbsoluteBarometricPressureCalculation(hexArray),
                    Unit = "kPa"
                },
                Pid.WideBandOxygenSensor1Current => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorCurrentCalculation(hexArray),
                    Unit = "mA"
                },
                Pid.WideBandOxygenSensor2Current => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorCurrentCalculation(hexArray),
                    Unit = "mA"
                },
                Pid.WideBandOxygenSensor3Current => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorCurrentCalculation(hexArray),
                    Unit = "mA"
                },
                Pid.WideBandOxygenSensor4Current => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorCurrentCalculation(hexArray),
                    Unit = "mA"
                },
                Pid.WideBandOxygenSensor5Current => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorCurrentCalculation(hexArray),
                    Unit = "mA"
                },
                Pid.WideBandOxygenSensor6Current => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorCurrentCalculation(hexArray),
                    Unit = "mA"
                },
                Pid.WideBandOxygenSensor7Current => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorCurrentCalculation(hexArray),
                    Unit = "mA"
                },
                Pid.WideBandOxygenSensor8Current => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = WideBandOxygenSensorCurrentCalculation(hexArray),
                    Unit = "mA"
                },
                Pid.CatalystTemperatureBank1Sensor1 => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = CatalystTemperatureSensorCalculation(hexArray),
                    Unit = "°C"
                },
                Pid.CatalystTemperatureBank2Sensor1 => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = CatalystTemperatureSensorCalculation(hexArray),
                    Unit = "°C"
                },
                Pid.CatalystTemperatureBank1Sensor2 => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = CatalystTemperatureSensorCalculation(hexArray),
                    Unit = "°C"
                },
                Pid.CatalystTemperatureBank2Sensor2 => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = CatalystTemperatureSensorCalculation(hexArray),
                    Unit = "°C"
                },
                _ => new PidData()
                {
                    PidName = pid.ToString(),
                    Result = -1,
                    Unit = ""
                },
            };
            return calculationResult;
        }

        private static decimal CalculatedEngineLoadCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Calculated engine load expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var result = int.Parse(hexArray[0], NumberStyles.HexNumber) / 2.55;

            return (decimal)result;
        }

        private static decimal EngineCoolantTemperatureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Engine coolant temperature expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var result = int.Parse(hexArray[0], NumberStyles.HexNumber) - 40;

            return result;
        }

        private static decimal FuelTrimCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Fuel trim expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = int.Parse(hexArray[0], NumberStyles.HexNumber);
            var result = a / 1.28m - 100;

            return decimal.Round(result, 1);
        }

        private static decimal FuelPressureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Fuel pressure expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var result = 3 * int.Parse(hexArray[0], NumberStyles.HexNumber);

            return result;
        }

        private static decimal IntakeManifoldAbsolutePressureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Intake manifold absolute pressure expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var result = int.Parse(hexArray[0], NumberStyles.HexNumber);

            return result;
        }

        private static decimal EngineSpeedCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Engine speed expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var b = (decimal)int.Parse(hexArray[1], NumberStyles.HexNumber);
            var result = (256 * a + b) / 4;

            return decimal.Round(result, 0);
        }

        private static decimal VehicleSpeedCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Vehicle speed expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            return int.Parse(hexArray[0], NumberStyles.HexNumber);
        }

        private static decimal TimingAdvanceCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Timing advance expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var result = a / 2 - 64;

            return decimal.Round(result, 1);
        }

        private static decimal IntakeAirTemperatureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Intake air temperature expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            return int.Parse(hexArray[0], NumberStyles.HexNumber) - 40;
        }

        private static decimal MassAirFlowSensorCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Mass air flow sensor expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var b = (decimal)int.Parse(hexArray[1], NumberStyles.HexNumber);
            var result = (256 * a + b) / 100;

            return decimal.Round(result, 2);
        }

        private static decimal ThrottlePositionCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Throttle Position expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var result = (100 * a) / 255;

            return decimal.Round(result, 2);
        }

        private static decimal OxygenSensorVoltageCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Oxygen Sensor expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var result = a / 200;

            return decimal.Round(result, 3);
        }

        private static decimal RunTimeSinceStartCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Run time since start expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = int.Parse(hexArray[0], NumberStyles.HexNumber);
            var b = int.Parse(hexArray[1], NumberStyles.HexNumber);

            return 256 * a + b;
        }

        private static decimal DistanceTravelSinceCheckEngineLightOnCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Distance travel since check engine light on expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = int.Parse(hexArray[0], NumberStyles.HexNumber);
            var b = int.Parse(hexArray[1], NumberStyles.HexNumber);

            return 256 * a + b;
        }

        private static decimal FuelRailPressureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Fuel rail pressure expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var b = (decimal)int.Parse(hexArray[1], NumberStyles.HexNumber);
            var result = (256 * a + b) * 0.079m;

            return decimal.Round(result, 3);
        }

        private static decimal FuelRailGaugePressureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Fuel rail gauge pressure expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = int.Parse(hexArray[0], NumberStyles.HexNumber);
            var b = int.Parse(hexArray[1], NumberStyles.HexNumber);

            return (256 * a + b) * 10;
        }

        private static decimal WideBandOxygenSensorVoltageCalculation(string[] hexArray)
        {
            if (hexArray.Length != 4)
                throw new VehicleDataException
                    ("Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var c = (decimal)int.Parse(hexArray[2], NumberStyles.HexNumber);
            var d = (decimal)int.Parse(hexArray[3], NumberStyles.HexNumber);
            var result = ((256 * c + d) * 8) / 65536;

            return decimal.Round(result, 1);
        }

        private static decimal CommandedEgrCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Commanded EGR expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            return int.Parse(hexArray[0], NumberStyles.HexNumber) * 100 / 255;
        }

        private static decimal FuelTankLevelCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Fuel tank level expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            return int.Parse(hexArray[0], NumberStyles.HexNumber) * 100 / 255;
        }

        private static decimal WarmupsSinceCodesClearedCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Warm-ups since codes cleared expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            return int.Parse(hexArray[0], NumberStyles.HexNumber);
        }

        private static decimal DistanceTraveledSinceCodesClearedCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Distance traveled since codes cleared expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = int.Parse(hexArray[0], NumberStyles.HexNumber);
            var b = int.Parse(hexArray[1], NumberStyles.HexNumber);
            return 256 * a + b;
        }

        private static decimal EvapSystemVaporPressureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Evap system vapor pressure expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var ab = (decimal)int.Parse(hexArray[0] + hexArray[1], NumberStyles.HexNumber);
            var result = 0.25m * ab - 8192;

            return decimal.Round(result, 2);
        }

        private static decimal AbsoluteBarometricPressureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Absolute barometric pressure expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            return int.Parse(hexArray[0], NumberStyles.HexNumber);
        }

        private static decimal WideBandOxygenSensorCurrentCalculation(string[] hexArray)
        {
            if (hexArray.Length != 4)
                throw new VehicleDataException
                    ("Wide band oxygen sensor current expects a 4 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var c = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var d = (decimal)int.Parse(hexArray[1], NumberStyles.HexNumber);
            var result = ((256 * c + d) / 256) - 128;

            return decimal.Round(result, 2);
        }

        private static decimal CatalystTemperatureSensorCalculation(string[] hexArray)
        {
            if (hexArray.Length != 2)
                throw new VehicleDataException
                    ("Catalyst temperature sensor expects a 2 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var b = (decimal)int.Parse(hexArray[1], NumberStyles.HexNumber);
            var result = ((256 * a + b) / 10) - 40;

            return decimal.Round(result, 1);
        }
    }
}
