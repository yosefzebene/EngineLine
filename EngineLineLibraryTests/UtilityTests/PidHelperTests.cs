using EngineLineLibrary.Exceptions;
using EngineLineLibrary.Vehicle.Enums;
using EngineLineLibrary.Vehicle.Helpers;
using FluentAssertions;

namespace EngineLineLibraryTests.UtilityTests
{
    public class PidHelperTests
    {
        [Theory]
        [InlineData(Pid.CalculatedEngineLoad, new[] { "ff" }, 100)]
        [InlineData(Pid.EngineCoolantTemperature, new[] { "ff" }, 215)]
        [InlineData(Pid.ShortTermFuelTrimBank1, new[] { "ff" }, 99.2)]
        [InlineData(Pid.LongTermFuelTrimBank1, new[] { "ff" }, 99.2)]
        [InlineData(Pid.ShortTermFuelTrimBank2, new[] { "ff" }, 99.2)]
        [InlineData(Pid.LongTermFuelTrimBank2, new[] { "ff" }, 99.2)]
        [InlineData(Pid.FuelPressure, new[] { "ff" }, 765)]
        [InlineData(Pid.IntakeManifoldAbsolutePressure, new[] { "ff" }, 255)]
        [InlineData(Pid.EngineSpeed, new[] { "ff", "ff" }, 16384)]
        [InlineData(Pid.VehicleSpeed, new[] { "ff" }, 255)]
        [InlineData(Pid.TimingAdvance, new[] { "ff" }, 63.5)]
        [InlineData(Pid.IntakeAirTemperature, new[] { "ff" }, 215)]
        [InlineData(Pid.MassAirFlowSensor, new[] { "ff", "ff" }, 655.35)]
        public void CalculateBasedOnPid_ShouldReturnCalculatedValue_WhenProvidedWithThePidAndValidHexArrayToCalculate(Pid pid, string[] hexArray, decimal expected)
        {
            var result = PidHelper.CalculateBasedOnPid(pid, hexArray);

            result.Should().Be(expected);
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
        public void CalculateBasedOnPid_ShouldThrowVehicleDataException_WhenProvidedWithThePidAndInvalidHexArrayToCalculate(Pid pid, string[] hexArray, string expectedMessage)
        {
            Action act = () => PidHelper.CalculateBasedOnPid(pid, hexArray);

            act.Should().Throw<VehicleDataException>()
                .WithMessage(expectedMessage);
        }
    }
}
