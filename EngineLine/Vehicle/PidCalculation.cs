using EngineLine.Exceptions;
using EngineLine.Vehicle.Enums;
using System.Globalization;

namespace EngineLine.Vehicle
{
    public static class PidCalculation
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

            var result = int.Parse(hexArray[0], NumberStyles.HexNumber);

            return result;
        }

        private static decimal TimingAdvanceCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Timing advance expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var a = (decimal)int.Parse(hexArray[0], NumberStyles.HexNumber);
            var result = a / 2 - 64;

            return result;
        }

        private static decimal IntakeAirTemperatureCalculation(string[] hexArray)
        {
            if (hexArray.Length != 1)
                throw new VehicleDataException
                    ("Intake air temperature expects a 1 byte response from the vehicle but got " + hexArray.Length + " instead.");

            var result = int.Parse(hexArray[0], NumberStyles.HexNumber) - 40;

            return result;
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
    }
}
