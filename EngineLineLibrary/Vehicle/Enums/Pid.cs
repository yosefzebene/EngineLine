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
        CalculatedEngineLoad,
        [NameAndUnit("Engine Coolant Temperature", "°C")]
        EngineCoolantTemperature,
        [NameAndUnit("Short Term Fuel Trim Bank 1", "%")]
        ShortTermFuelTrimBank1,
        [NameAndUnit("Long Term Fuel Trim Bank 1", "%")] 
        LongTermFuelTrimBank1,
        [NameAndUnit("Short Term Fuel Trim Bank 2", "%")]
        ShortTermFuelTrimBank2,
        [NameAndUnit("Long Term Fuel Trim Bank 2", "%")] 
        LongTermFuelTrimBank2,
        [NameAndUnit("Fuel Pressure", "kPa")] 
        FuelPressure,
        [NameAndUnit("Intake Manifold Absolute Pressure", "kPa")] 
        IntakeManifoldAbsolutePressure,
        [NameAndUnit("Engine Speed", "rpm")]
        EngineSpeed,
        [NameAndUnit("Vehicle Speed", "km/h")]
        VehicleSpeed,
        [NameAndUnit("Timing Advance", "°")] 
        TimingAdvance,
        [NameAndUnit("Intake Air Temperature", "°C")] 
        IntakeAirTemperature,
        [NameAndUnit("Mass Air Flow Sensor", "g/s")] 
        MassAirFlowSensor,
        [NameAndUnit("Throttle Position", "%")]
        ThrottlePosition,
        [NameAndUnit("Commanded Secondary Air Status", "")] 
        CommandedSecondaryAirStatus,
        [NameAndUnit("Oxygen Sensors Present In 2 Banks", "")] 
        OxygenSensorsPresent2Banks,
        [NameAndUnit("Oxygen Sensor 1 Voltage", "V")] 
        OxygenSensor1Voltage,
        [NameAndUnit("Oxygen Sensor 2 Voltage", "V")]
        OxygenSensor2Voltage,
        [NameAndUnit("Oxygen Sensor 3 Voltage", "V")]
        OxygenSensor3Voltage,
        [NameAndUnit("Oxygen Sensor 4 Voltage", "V")]
        OxygenSensor4Voltage,
        [NameAndUnit("Oxygen Sensor 5 Voltage", "V")]
        OxygenSensor5Voltage,
        [NameAndUnit("Oxygen Sensor 6 Voltage", "V")]
        OxygenSensor6Voltage,
        [NameAndUnit("Oxygen Sensor 7 Voltage", "V")]
        OxygenSensor7Voltage,
        [NameAndUnit("Oxygen Sensor 8 Voltage", "V")]
        OxygenSensor8Voltage,
        [NameAndUnit("Obd Standard", "")]
        ObdStandard,
        [NameAndUnit("Oxygen Sensors Present In 4 Banks", "")]
        OxygenSensorsPresent4Banks,
        [NameAndUnit("Auxiliary Input Status", "")]
        AuxiliaryInputStatus,
        [NameAndUnit("Run Time Since Start", "s")]
        RunTimeSinceStart,
        [NameAndUnit("Supported PIDs 21 To 40", "")]
        SupportedPids21to40,
        [NameAndUnit("Distance Travel Since Check Engine Light On", "km")] 
        DistanceTravelSinceCheckEngineLightOn,
        [NameAndUnit("Fuel Rail Pressure", "kPa")] 
        FuelRailPressure,
        [NameAndUnit("Fuel Rail Gauge Pressure", "kPa")] 
        FuelRailGaugePressure,
        [NameAndUnit("Wide Band Oxygen Sensor 1 Voltage", "V")]
        WideBandOxygenSensor1Voltage,
        [NameAndUnit("Wide Band Oxygen Sensor 2 Voltage", "V")] 
        WideBandOxygenSensor2Voltage,
        [NameAndUnit("Wide Band Oxygen Sensor 3 Voltage", "V")]
        WideBandOxygenSensor3Voltage,
        [NameAndUnit("Wide Band Oxygen Sensor 4 Voltage", "V")]
        WideBandOxygenSensor4Voltage,
        [NameAndUnit("Wide Band Oxygen Sensor 5 Voltage", "V")]
        WideBandOxygenSensor5Voltage,
        [NameAndUnit("Wide Band Oxygen Sensor 6 Voltage", "V")]
        WideBandOxygenSensor6Voltage,
        [NameAndUnit("Wide Band Oxygen Sensor 7 Voltage", "V")]
        WideBandOxygenSensor7Voltage,
        [NameAndUnit("Wide Band Oxygen Sensor 8 Voltage", "V")]
        WideBandOxygenSensor8Voltage,
        [NameAndUnit("Commanded Egr", "%")]
        CommandedEgr,
        [NameAndUnit("Egr Error", "%")]
        EgrError,
        [NameAndUnit("Commanded Evap Purge", "%")]
        CommandedEvapPurge,
        [NameAndUnit("Fuel Tank Level", "%")]
        FuelTankLevel,
        [NameAndUnit("Warmups Since Codes Cleared", "")]
        WarmupsSinceCodesCleared,
        [NameAndUnit("Distance Traveled Since Codes Cleared", "km")]
        DistanceTraveledSinceCodesCleared,
        [NameAndUnit("Evap System Vapor Pressure", "Pa")]
        EvapSystemVaporPressure,
        [NameAndUnit("Absolute Barometric Pressure", "kPa")]
        AbsoluteBarometricPressure,
        [NameAndUnit("Wide Band Oxygen Sensor 1 Current", "mA")]
        WideBandOxygenSensor1Current,
        [NameAndUnit("Wide Band Oxygen Sensor 2 Current", "mA")]
        WideBandOxygenSensor2Current,
        [NameAndUnit("Wide Band Oxygen Sensor 3 Current", "mA")]
        WideBandOxygenSensor3Current,
        [NameAndUnit("Wide Band Oxygen Sensor 4 Current", "mA")]
        WideBandOxygenSensor4Current,
        [NameAndUnit("Wide Band Oxygen Sensor 5 Current", "mA")]
        WideBandOxygenSensor5Current,
        [NameAndUnit("Wide Band Oxygen Sensor 6 Current", "mA")]
        WideBandOxygenSensor6Current,
        [NameAndUnit("Wide Band Oxygen Sensor 7 Current", "mA")]
        WideBandOxygenSensor7Current,
        [NameAndUnit("Wide Band Oxygen Sensor 8 Current", "mA")]
        WideBandOxygenSensor8Current,
        [NameAndUnit("Catalyst Temperature Bank 1 Sensor 1", "°C")]
        CatalystTemperatureBank1Sensor1,
        [NameAndUnit("Catalyst Temperature Bank 2 Sensor 1", "°C")]
        CatalystTemperatureBank2Sensor1,
        [NameAndUnit("Catalyst Temperature Bank 1 Sensor 2", "°C")]
        CatalystTemperatureBank1Sensor2,
        [NameAndUnit("Catalyst Temperature Bank 2 Sensor 2", "°C")]
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
    }
}
