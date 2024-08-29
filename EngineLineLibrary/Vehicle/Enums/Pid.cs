using System.Reflection;

namespace EngineLineLibrary.Vehicle.Enums
{
    public enum Pid
    {
        [NameAndUnit("Supported PIDs 1 To 20", "")]
        SupportedPids1to20,

        [NameAndUnit("Monitor Status Since DTC Cleared", "")]
        MonitorStatusSinceDtcCleared,

        [NameAndUnit("DTC That Caused Freeze Frame", "")]
        DtcThatCausedFreezeFrame,

        [NameAndUnit("Fuel System Status", "")]
        FuelSystemStatus,

        [NameAndUnit("Calculated Engine Load", "%")]
        [MinAndMax(0, 100)]
        CalculatedEngineLoad,

        [NameAndUnit("Engine Coolant Temperature", "°C")]
        [MinAndMax(-40, 215)]
        EngineCoolantTemperature,

        [NameAndUnit("Short Term Fuel Trim Bank 1", "%")]
        [MinAndMax(-100, 100)]
        ShortTermFuelTrimBank1,

        [NameAndUnit("Long Term Fuel Trim Bank 1", "%")]
        [MinAndMax(-100, 100)]
        LongTermFuelTrimBank1,

        [NameAndUnit("Short Term Fuel Trim Bank 2", "%")]
        [MinAndMax(-100, 100)]
        ShortTermFuelTrimBank2,

        [NameAndUnit("Long Term Fuel Trim Bank 2", "%")]
        [MinAndMax(-100, 100)]
        LongTermFuelTrimBank2,

        [NameAndUnit("Fuel Pressure", "kPa")]
        [MinAndMax(0, 765)]
        FuelPressure,

        [NameAndUnit("Intake Manifold Absolute Pressure", "kPa")]
        [MinAndMax(0, 255)]
        IntakeManifoldAbsolutePressure,

        [NameAndUnit("Engine Speed", "rpm")]
        [MinAndMax(0, 16_384)]
        EngineSpeed,

        [NameAndUnit("Vehicle Speed", "km/h")]
        [MinAndMax(0, 255)]
        VehicleSpeed,

        [NameAndUnit("Timing Advance", "°")]
        [MinAndMax(-64, 64)]
        TimingAdvance,

        [NameAndUnit("Intake Air Temperature", "°C")]
        [MinAndMax(-40, 215)]
        IntakeAirTemperature,

        [NameAndUnit("Mass Air Flow Sensor", "g/s")]
        [MinAndMax(0, 656)]
        MassAirFlowSensor,

        [NameAndUnit("Throttle Position", "%")]
        [MinAndMax(0, 100)]
        ThrottlePosition,

        [NameAndUnit("Commanded Secondary Air Status", "")] 
        CommandedSecondaryAirStatus,

        [NameAndUnit("Oxygen Sensors Present In 2 Banks", "")] 
        OxygenSensorsPresent2Banks,

        [NameAndUnit("Oxygen Sensor 1 Voltage", "V")]
        [MinAndMax(0, 2)]
        OxygenSensor1Voltage,

        [NameAndUnit("Oxygen Sensor 2 Voltage", "V")]
        [MinAndMax(0, 2)]
        OxygenSensor2Voltage,

        [NameAndUnit("Oxygen Sensor 3 Voltage", "V")]
        [MinAndMax(0, 2)]
        OxygenSensor3Voltage,

        [NameAndUnit("Oxygen Sensor 4 Voltage", "V")]
        [MinAndMax(0, 2)]
        OxygenSensor4Voltage,

        [NameAndUnit("Oxygen Sensor 5 Voltage", "V")]
        [MinAndMax(0, 2)]
        OxygenSensor5Voltage,

        [NameAndUnit("Oxygen Sensor 6 Voltage", "V")]
        [MinAndMax(0, 2)]
        OxygenSensor6Voltage,

        [NameAndUnit("Oxygen Sensor 7 Voltage", "V")]
        [MinAndMax(0, 2)]
        OxygenSensor7Voltage,

        [NameAndUnit("Oxygen Sensor 8 Voltage", "V")]
        [MinAndMax(0, 2)]
        OxygenSensor8Voltage,

        [NameAndUnit("Obd Standard", "")]
        [MinAndMax(1, 250)]
        ObdStandard,

        [NameAndUnit("Oxygen Sensors Present In 4 Banks", "")]
        OxygenSensorsPresent4Banks,

        [NameAndUnit("Auxiliary Input Status", "")]
        AuxiliaryInputStatus,

        [NameAndUnit("Run Time Since Start", "s")]
        [MinAndMax(0, 65_535)]
        RunTimeSinceStart,

        [NameAndUnit("Supported PIDs 21 To 40", "")]
        SupportedPids21to40,

        [NameAndUnit("Distance Travel Since Check Engine Light On", "km")]
        [MinAndMax(0, 65_535)]
        DistanceTravelSinceCheckEngineLightOn,

        [NameAndUnit("Fuel Rail Pressure", "kPa")]
        [MinAndMax(0, 5178)]
        FuelRailPressure,

        [NameAndUnit("Fuel Rail Gauge Pressure", "kPa")]
        [MinAndMax(0, 655_350)]
        FuelRailGaugePressure,

        [NameAndUnit("Wide Band Oxygen Sensor 1 Voltage", "V")]
        [MinAndMax(0, 8)]
        WideBandOxygenSensor1Voltage,

        [NameAndUnit("Wide Band Oxygen Sensor 2 Voltage", "V")]
        [MinAndMax(0, 8)]
        WideBandOxygenSensor2Voltage,

        [NameAndUnit("Wide Band Oxygen Sensor 3 Voltage", "V")]
        [MinAndMax(0, 8)]
        WideBandOxygenSensor3Voltage,

        [NameAndUnit("Wide Band Oxygen Sensor 4 Voltage", "V")]
        [MinAndMax(0, 8)]
        WideBandOxygenSensor4Voltage,

        [NameAndUnit("Wide Band Oxygen Sensor 5 Voltage", "V")]
        [MinAndMax(0, 8)]
        WideBandOxygenSensor5Voltage,

        [NameAndUnit("Wide Band Oxygen Sensor 6 Voltage", "V")]
        [MinAndMax(0, 8)]
        WideBandOxygenSensor6Voltage,

        [NameAndUnit("Wide Band Oxygen Sensor 7 Voltage", "V")]
        [MinAndMax(0, 8)]
        WideBandOxygenSensor7Voltage,

        [NameAndUnit("Wide Band Oxygen Sensor 8 Voltage", "V")]
        [MinAndMax(0, 8)]
        WideBandOxygenSensor8Voltage,

        [NameAndUnit("Commanded Egr", "%")]
        [MinAndMax(0, 100)]
        CommandedEgr,

        [NameAndUnit("Egr Error", "%")]
        [MinAndMax(-100, 100)]
        EgrError,

        [NameAndUnit("Commanded Evap Purge", "%")]
        [MinAndMax(0, 100)]
        CommandedEvapPurge,

        [NameAndUnit("Fuel Tank Level", "%")]
        [MinAndMax(0, 100)]
        FuelTankLevel,

        [NameAndUnit("Warmups Since Codes Cleared", "")]
        [MinAndMax(0, 255)]
        WarmupsSinceCodesCleared,

        [NameAndUnit("Distance Traveled Since Codes Cleared", "km")]
        [MinAndMax(0, 65_535)]
        DistanceTraveledSinceCodesCleared,

        [NameAndUnit("Evap System Vapor Pressure", "Pa")]
        [MinAndMax(-8192, 8192)]
        EvapSystemVaporPressure,

        [NameAndUnit("Absolute Barometric Pressure", "kPa")]
        [MinAndMax(0, 255)]
        AbsoluteBarometricPressure,

        [NameAndUnit("Wide Band Oxygen Sensor 1 Current", "mA")]
        [MinAndMax(-128, 128)]
        WideBandOxygenSensor1Current,

        [NameAndUnit("Wide Band Oxygen Sensor 2 Current", "mA")]
        [MinAndMax(-128, 128)]
        WideBandOxygenSensor2Current,

        [NameAndUnit("Wide Band Oxygen Sensor 3 Current", "mA")]
        [MinAndMax(-128, 128)]
        WideBandOxygenSensor3Current,

        [NameAndUnit("Wide Band Oxygen Sensor 4 Current", "mA")]
        [MinAndMax(-128, 128)]
        WideBandOxygenSensor4Current,

        [NameAndUnit("Wide Band Oxygen Sensor 5 Current", "mA")]
        [MinAndMax(-128, 128)]
        WideBandOxygenSensor5Current,

        [NameAndUnit("Wide Band Oxygen Sensor 6 Current", "mA")]
        [MinAndMax(-128, 128)]
        WideBandOxygenSensor6Current,

        [NameAndUnit("Wide Band Oxygen Sensor 7 Current", "mA")]
        [MinAndMax(-128, 128)]
        WideBandOxygenSensor7Current,

        [NameAndUnit("Wide Band Oxygen Sensor 8 Current", "mA")]
        [MinAndMax(-128, 128)]
        WideBandOxygenSensor8Current,

        [NameAndUnit("Catalyst Temperature Bank 1 Sensor 1", "°C")]
        [MinAndMax(-128, 128)]
        CatalystTemperatureBank1Sensor1,

        [NameAndUnit("Catalyst Temperature Bank 2 Sensor 1", "°C")]
        [MinAndMax(-128, 128)]
        CatalystTemperatureBank2Sensor1,

        [NameAndUnit("Catalyst Temperature Bank 1 Sensor 2", "°C")]
        [MinAndMax(-128, 128)]
        CatalystTemperatureBank1Sensor2,

        [NameAndUnit("Catalyst Temperature Bank 2 Sensor 2", "°C")]
        [MinAndMax(-128, 128)]
        CatalystTemperatureBank2Sensor2,
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class NameAndUnitAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Unit { get; private set; }

        public NameAndUnitAttribute(string name, string unit)
        {
            Name = name;
            Unit = unit;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class MinAndMaxAttribute : Attribute
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public MinAndMaxAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }

    public static class PidExtensions
    {
        public static string GetName(this Pid pid)
        {
            var type = pid.GetType();
            var fieldInfo = type.GetField(pid.ToString());

            if (fieldInfo != null)
            {
                var attribute = fieldInfo.GetCustomAttribute<NameAndUnitAttribute>();
                return attribute?.Name ?? "";
            }

            return "";
        }

        public static string GetUnit(this Pid pid)
        {
            var type = pid.GetType();
            var fieldInfo = type.GetField(pid.ToString());

            if (fieldInfo != null)
            {
                var attribute = fieldInfo.GetCustomAttribute<NameAndUnitAttribute>();
                return attribute?.Unit ?? "";
            }

            return "";
        }

        public static int GetMin(this Pid pid)
        {
            var type = pid.GetType();
            var fieldInfo = type.GetField(pid.ToString());

            if (fieldInfo != null)
            {
                var attribute = fieldInfo.GetCustomAttribute<MinAndMaxAttribute>();
                return attribute?.Min ?? 0;
            }

            return 0;
        }

        public static int GetMax(this Pid pid)
        {
            var type = pid.GetType();
            var fieldInfo = type.GetField(pid.ToString());

            if (fieldInfo != null)
            {
                var attribute = fieldInfo.GetCustomAttribute<MinAndMaxAttribute>();
                return attribute?.Max ?? 0;
            }

            return 0;
        }
    }
}
