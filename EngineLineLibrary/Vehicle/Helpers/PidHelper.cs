using EngineLineLibrary.Exceptions;
using EngineLineLibrary.Vehicle.Enums;
using System.Globalization;
using System.Reflection.Metadata;

namespace EngineLineLibrary.Vehicle.Helpers
{
    public static class PidHelper
    {
        public static decimal CalculateBasedOnPid(Pid pid, string[] hexArray)
        {
            var calculationResult = pid switch
            {
                Pid.CalculatedEngineLoad => CalculatedEngineLoadCalculation(hexArray),
                Pid.EngineCoolantTemperature => EngineCoolantTemperatureCalculation(hexArray),
                Pid.ShortTermFuelTrimBank1 => FuelTrimCalculation(hexArray),
                Pid.LongTermFuelTrimBank1 => FuelTrimCalculation(hexArray),
                Pid.ShortTermFuelTrimBank2 => FuelTrimCalculation(hexArray),
                Pid.LongTermFuelTrimBank2 => FuelTrimCalculation(hexArray),
                Pid.FuelPressure => FuelPressureCalculation(hexArray),
                Pid.IntakeManifoldAbsolutePressure => IntakeManifoldAbsolutePressureCalculation(hexArray),
                Pid.EngineSpeed => EngineSpeedCalculation(hexArray),
                Pid.VehicleSpeed => VehicleSpeedCalculation(hexArray),
                Pid.TimingAdvance => TimingAdvanceCalculation(hexArray),
                Pid.IntakeAirTemperature => IntakeAirTemperatureCalculation(hexArray),
                Pid.MassAirFlowSensor => MassAirFlowSensorCalculation(hexArray),
                Pid.ThrottlePosition => ThrottlePositionCalculation(hexArray),
                Pid.OxygenSensor1Voltage => OxygenSensorVoltageCalculation(hexArray),
                Pid.OxygenSensor2Voltage => OxygenSensorVoltageCalculation(hexArray),
                Pid.OxygenSensor3Voltage => OxygenSensorVoltageCalculation(hexArray),
                Pid.OxygenSensor4Voltage => OxygenSensorVoltageCalculation(hexArray),
                Pid.OxygenSensor5Voltage => OxygenSensorVoltageCalculation(hexArray),
                Pid.OxygenSensor6Voltage => OxygenSensorVoltageCalculation(hexArray),
                Pid.OxygenSensor7Voltage => OxygenSensorVoltageCalculation(hexArray),
                Pid.OxygenSensor8Voltage => OxygenSensorVoltageCalculation(hexArray),
                Pid.RunTimeSinceStart => RunTimeSinceStartCalculation(hexArray),
                Pid.DistanceTravelSinceCheckEngineLightOn => DistanceTravelSinceCheckEngineLightOnCalculation(hexArray),
                Pid.FuelRailPressure => FuelRailPressureCalculation(hexArray),
                Pid.FuelRailGaugePressure => FuelRailGaugePressureCalculation(hexArray),
                Pid.WideBandOxygenSensor1Voltage => WideBandOxygenSensorVoltageCalculation(hexArray),
                Pid.WideBandOxygenSensor2Voltage => WideBandOxygenSensorVoltageCalculation(hexArray),
                Pid.WideBandOxygenSensor3Voltage => WideBandOxygenSensorVoltageCalculation(hexArray),
                Pid.WideBandOxygenSensor4Voltage => WideBandOxygenSensorVoltageCalculation(hexArray),
                Pid.WideBandOxygenSensor5Voltage => WideBandOxygenSensorVoltageCalculation(hexArray),
                Pid.WideBandOxygenSensor6Voltage => WideBandOxygenSensorVoltageCalculation(hexArray),
                Pid.WideBandOxygenSensor7Voltage => WideBandOxygenSensorVoltageCalculation(hexArray),
                Pid.WideBandOxygenSensor8Voltage => WideBandOxygenSensorVoltageCalculation(hexArray),
                Pid.CommandedEgr => CommandedEgrCalculation(hexArray),
                Pid.FuelTankLevel => FuelTankLevelCalculation(hexArray),
                Pid.WarmupsSinceCodesCleared => WarmupsSinceCodesClearedCalculation(hexArray),
                Pid.DistanceTraveledSinceCodesCleared => DistanceTraveledSinceCodesClearedCalculation(hexArray),
                Pid.EvapSystemVaporPressure => EvapSystemVaporPressureCalculation(hexArray),
                Pid.AbsoluteBarometricPressure => AbsoluteBarometricPressureCalculation(hexArray),
                Pid.WideBandOxygenSensor1Current => WideBandOxygenSensorCurrentCalculation(hexArray),
                Pid.WideBandOxygenSensor2Current => WideBandOxygenSensorCurrentCalculation(hexArray),
                Pid.WideBandOxygenSensor3Current => WideBandOxygenSensorCurrentCalculation(hexArray),
                Pid.WideBandOxygenSensor4Current => WideBandOxygenSensorCurrentCalculation(hexArray),
                Pid.WideBandOxygenSensor5Current => WideBandOxygenSensorCurrentCalculation(hexArray),
                Pid.WideBandOxygenSensor6Current => WideBandOxygenSensorCurrentCalculation(hexArray),
                Pid.WideBandOxygenSensor7Current => WideBandOxygenSensorCurrentCalculation(hexArray),
                Pid.WideBandOxygenSensor8Current => WideBandOxygenSensorCurrentCalculation(hexArray),
                Pid.CatalystTemperatureBank1Sensor1 => CatalystTemperatureSensorCalculation(hexArray),
                Pid.CatalystTemperatureBank2Sensor1 => CatalystTemperatureSensorCalculation(hexArray),
                Pid.CatalystTemperatureBank1Sensor2 => CatalystTemperatureSensorCalculation(hexArray),
                Pid.CatalystTemperatureBank2Sensor2 => CatalystTemperatureSensorCalculation(hexArray),
                _ => -1,
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
