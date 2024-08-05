using EngineLineLibrary.Exceptions;
using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Helpers;
using FluentAssertions;

namespace EngineLineLibraryTests.UtilityTests
{
    public class PidHelperTests
    {
        [Theory]
        [InlineData(Pid.CalculatedEngineLoad, new[] { "ff" }, 100, "%")]
        [InlineData(Pid.EngineCoolantTemperature, new[] { "ff" }, 215, "°C")]
        [InlineData(Pid.ShortTermFuelTrimBank1, new[] { "ff" }, 99.2, "%")]
        [InlineData(Pid.LongTermFuelTrimBank1, new[] { "ff" }, 99.2, "%")]
        [InlineData(Pid.ShortTermFuelTrimBank2, new[] { "ff" }, 99.2, "%")]
        [InlineData(Pid.LongTermFuelTrimBank2, new[] { "ff" }, 99.2, "%")]
        [InlineData(Pid.FuelPressure, new[] { "ff" }, 765, "kPa")]
        [InlineData(Pid.IntakeManifoldAbsolutePressure, new[] { "ff" }, 255, "kPa")]
        [InlineData(Pid.EngineSpeed, new[] { "ff", "ff" }, 16384, "rpm")]
        [InlineData(Pid.VehicleSpeed, new[] { "ff" }, 255, "km/h")]
        [InlineData(Pid.TimingAdvance, new[] { "ff" }, 63.5, "°")]
        [InlineData(Pid.IntakeAirTemperature, new[] { "ff" }, 215, "°C")]
        [InlineData(Pid.MassAirFlowSensor, new[] { "ff", "ff" }, 655.35, "g/s")]
        [InlineData(Pid.ThrottlePosition, new[] { "ff" }, 100.00, "%")]
        [InlineData(Pid.OxygenSensor1Voltage, new[] { "ff", "ff" }, 1.275, "V")]
        [InlineData(Pid.OxygenSensor2Voltage, new[] { "ff", "ff" }, 1.275, "V")]
        [InlineData(Pid.OxygenSensor3Voltage, new[] { "ff", "ff" }, 1.275, "V")]
        [InlineData(Pid.OxygenSensor4Voltage, new[] { "ff", "ff" }, 1.275, "V")]
        [InlineData(Pid.OxygenSensor5Voltage, new[] { "ff", "ff" }, 1.275, "V")]
        [InlineData(Pid.OxygenSensor6Voltage, new[] { "ff", "ff" }, 1.275, "V")]
        [InlineData(Pid.OxygenSensor7Voltage, new[] { "ff", "ff" }, 1.275, "V")]
        [InlineData(Pid.OxygenSensor8Voltage, new[] { "ff", "ff" }, 1.275, "V")]
        [InlineData(Pid.RunTimeSinceStart, new[] { "ff", "ff" }, 65535, "s")]
        [InlineData(Pid.DistanceTravelSinceCheckEngineLightOn, new[] { "ff", "ff" }, 65535, "km")]
        [InlineData(Pid.FuelRailPressure, new[] { "ff", "ff" }, 5177.265, "kPa")]
        [InlineData(Pid.FuelRailGaugePressure, new[] { "ff", "ff" }, 655350, "kPa")]
        [InlineData(Pid.WideBandOxygenSensor1Voltage, new[] { "ff", "ff", "ff", "ff" }, 8, "V")]
        [InlineData(Pid.WideBandOxygenSensor2Voltage, new[] { "ff", "ff", "ff", "ff" }, 8, "V")]
        [InlineData(Pid.WideBandOxygenSensor3Voltage, new[] { "ff", "ff", "ff", "ff" }, 8, "V")]
        [InlineData(Pid.WideBandOxygenSensor4Voltage, new[] { "ff", "ff", "ff", "ff" }, 8, "V")]
        [InlineData(Pid.WideBandOxygenSensor5Voltage, new[] { "ff", "ff", "ff", "ff" }, 8, "V")]
        [InlineData(Pid.WideBandOxygenSensor6Voltage, new[] { "ff", "ff", "ff", "ff" }, 8, "V")]
        [InlineData(Pid.WideBandOxygenSensor7Voltage, new[] { "ff", "ff", "ff", "ff" }, 8, "V")]
        [InlineData(Pid.WideBandOxygenSensor8Voltage, new[] { "ff", "ff", "ff", "ff" }, 8, "V")]
        [InlineData(Pid.CommandedEgr, new[] { "ff" }, 100, "%")]
        [InlineData(Pid.FuelTankLevel, new[] { "ff" }, 100, "%")]
        [InlineData(Pid.WarmupsSinceCodesCleared, new[] { "ff" }, 255, "")]
        [InlineData(Pid.DistanceTraveledSinceCodesCleared, new[] { "ff", "ff" }, 65535, "km")]
        [InlineData(Pid.EvapSystemVaporPressure, new[] { "ff", "ff" }, 8191.75, "Pa")]
        [InlineData(Pid.AbsoluteBarometricPressure, new[] { "ff" }, 255, "kPa")]
        [InlineData(Pid.WideBandOxygenSensor1Current, new[] { "ff", "ff", "ff", "ff" }, 128, "mA")]
        [InlineData(Pid.WideBandOxygenSensor2Current, new[] { "ff", "ff", "ff", "ff" }, 128, "mA")]
        [InlineData(Pid.WideBandOxygenSensor3Current, new[] { "ff", "ff", "ff", "ff" }, 128, "mA")]
        [InlineData(Pid.WideBandOxygenSensor4Current, new[] { "ff", "ff", "ff", "ff" }, 128, "mA")]
        [InlineData(Pid.WideBandOxygenSensor5Current, new[] { "ff", "ff", "ff", "ff" }, 128, "mA")]
        [InlineData(Pid.WideBandOxygenSensor6Current, new[] { "ff", "ff", "ff", "ff" }, 128, "mA")]
        [InlineData(Pid.WideBandOxygenSensor7Current, new[] { "ff", "ff", "ff", "ff" }, 128, "mA")]
        [InlineData(Pid.WideBandOxygenSensor8Current, new[] { "ff", "ff", "ff", "ff" }, 128, "mA")]
        [InlineData(Pid.CatalystTemperatureBank1Sensor1, new[] { "ff", "ff" }, 6513.5, "°C")]
        [InlineData(Pid.CatalystTemperatureBank2Sensor1, new[] { "ff", "ff" }, 6513.5, "°C")]
        [InlineData(Pid.CatalystTemperatureBank1Sensor2, new[] { "ff", "ff" }, 6513.5, "°C")]
        [InlineData(Pid.CatalystTemperatureBank2Sensor2, new[] { "ff", "ff" }, 6513.5, "°C")]
        public void CalculateBasedOnPid_ShouldReturnCalculatedValue_WhenProvidedWithThePidAndValidHexArrayToCalculate(Pid pid, string[] hexArray, decimal expectedResult, string expectedUnit)
        {
            var result = PidHelper.CalculateBasedOnPid(pid, hexArray);

            result.Result.Should().Be(expectedResult);
            result.Unit.Should().Be(expectedUnit);
        }

        [Theory]
        [InlineData(Pid.CalculatedEngineLoad, new[] { "ff", "ff" }, "Calculated engine load expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.EngineCoolantTemperature, new[] { "ff", "ff" }, "Engine coolant temperature expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.ShortTermFuelTrimBank1, new[] { "ff", "ff" }, "Fuel trim expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.LongTermFuelTrimBank1, new[] { "ff", "ff" }, "Fuel trim expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.ShortTermFuelTrimBank2, new[] { "ff", "ff" }, "Fuel trim expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.LongTermFuelTrimBank2, new[] { "ff", "ff" }, "Fuel trim expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.FuelPressure, new[] { "ff", "ff" }, "Fuel pressure expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.IntakeManifoldAbsolutePressure, new[] { "ff", "ff" }, "Intake manifold absolute pressure expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.EngineSpeed, new[] { "ff" }, "Engine speed expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.VehicleSpeed, new[] { "ff", "ff" }, "Vehicle speed expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.TimingAdvance, new[] { "ff", "ff" }, "Timing advance expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.IntakeAirTemperature, new[] { "ff", "ff" }, "Intake air temperature expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.MassAirFlowSensor, new[] { "ff" }, "Mass air flow sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.ThrottlePosition, new[] { "ff", "ff" }, "Throttle Position expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.OxygenSensor1Voltage, new[] { "ff" }, "Oxygen Sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.OxygenSensor2Voltage, new[] { "ff" }, "Oxygen Sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.OxygenSensor3Voltage, new[] { "ff" }, "Oxygen Sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.OxygenSensor4Voltage, new[] { "ff" }, "Oxygen Sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.OxygenSensor5Voltage, new[] { "ff" }, "Oxygen Sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.OxygenSensor6Voltage, new[] { "ff" }, "Oxygen Sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.OxygenSensor7Voltage, new[] { "ff" }, "Oxygen Sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.OxygenSensor8Voltage, new[] { "ff" }, "Oxygen Sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.RunTimeSinceStart, new[] { "ff" }, "Run time since start expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.DistanceTravelSinceCheckEngineLightOn, new[] { "ff" }, "Distance travel since check engine light on expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.FuelRailPressure, new[] { "ff" }, "Fuel rail pressure expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.FuelRailGaugePressure, new[] { "ff" }, "Fuel rail gauge pressure expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.WideBandOxygenSensor1Voltage, new[] { "ff" }, "Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.WideBandOxygenSensor2Voltage, new[] { "ff" }, "Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.WideBandOxygenSensor3Voltage, new[] { "ff" }, "Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.WideBandOxygenSensor4Voltage, new[] { "ff" }, "Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.WideBandOxygenSensor5Voltage, new[] { "ff" }, "Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.WideBandOxygenSensor6Voltage, new[] { "ff" }, "Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.WideBandOxygenSensor7Voltage, new[] { "ff" }, "Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.WideBandOxygenSensor8Voltage, new[] { "ff" }, "Wide band oxygen sensor voltage expects a 4 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.CommandedEgr, new[] { "ff", "ff" }, "Commanded EGR expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.FuelTankLevel, new[] { "ff", "ff" }, "Fuel tank level expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WarmupsSinceCodesCleared, new[] { "ff", "ff" }, "Warm-ups since codes cleared expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.DistanceTraveledSinceCodesCleared, new[] { "ff" }, "Distance traveled since codes cleared expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.EvapSystemVaporPressure, new[] { "ff" }, "Evap system vapor pressure expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.AbsoluteBarometricPressure, new[] { "ff", "ff" }, "Absolute barometric pressure expects a 1 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WideBandOxygenSensor1Current, new[] { "ff", "ff" }, "Wide band oxygen sensor current expects a 4 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WideBandOxygenSensor2Current, new[] { "ff", "ff" }, "Wide band oxygen sensor current expects a 4 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WideBandOxygenSensor3Current, new[] { "ff", "ff" }, "Wide band oxygen sensor current expects a 4 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WideBandOxygenSensor4Current, new[] { "ff", "ff" }, "Wide band oxygen sensor current expects a 4 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WideBandOxygenSensor5Current, new[] { "ff", "ff" }, "Wide band oxygen sensor current expects a 4 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WideBandOxygenSensor6Current, new[] { "ff", "ff" }, "Wide band oxygen sensor current expects a 4 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WideBandOxygenSensor7Current, new[] { "ff", "ff" }, "Wide band oxygen sensor current expects a 4 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.WideBandOxygenSensor8Current, new[] { "ff", "ff" }, "Wide band oxygen sensor current expects a 4 byte response from the vehicle but got 2 instead.")]
        [InlineData(Pid.CatalystTemperatureBank1Sensor1, new[] { "ff" }, "Catalyst temperature sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.CatalystTemperatureBank2Sensor1, new[] { "ff" }, "Catalyst temperature sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.CatalystTemperatureBank1Sensor2, new[] { "ff" }, "Catalyst temperature sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        [InlineData(Pid.CatalystTemperatureBank2Sensor2, new[] { "ff" }, "Catalyst temperature sensor expects a 2 byte response from the vehicle but got 1 instead.")]
        public void CalculateBasedOnPid_ShouldThrowVehicleDataException_WhenProvidedWithThePidAndInvalidHexArrayToCalculate(Pid pid, string[] hexArray, string expectedMessage)
        {
            Action act = () => PidHelper.CalculateBasedOnPid(pid, hexArray);

            act.Should().Throw<VehicleDataException>()
                .WithMessage(expectedMessage);
        }
    }
}
