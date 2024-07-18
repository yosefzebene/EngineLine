using EngineLineLibrary.Vehicle;
using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Vehicle.Models;
using FluentAssertions;
using Moq;

namespace EngineLineLibraryTests.VehicleTests
{
    public class DiagnosticTroubleCodeHandlerTests
    {
        private readonly Mock<IObd2Device> _deviceMock;

        public DiagnosticTroubleCodeHandlerTests()
        {
            _deviceMock = new Mock<IObd2Device>();
        }

        [Fact]
        public void GetReportedDiagnosticCodes_ShouldReturnListOfDiagnosticCodes_WhenTheResponseIsOneCode()
        {
            _deviceMock.Setup(m => m.Query(It.IsAny<string>())).Returns("43 01 03 00 00 00 00");

            var expected = new List<DiagnosticTroubleCode>
            {
                new() { Code = "P0103", System = "Powertrain", Subsystem = "Fuel and air metering", Description = "Mass or Volume Air Flow Circuit High Input" }
            };

            var sut = new DiagnosticTroubleCodeHandler(_deviceMock.Object);
            var result = sut.GetReportedDiagnosticTroubleCodes();

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetReportedDiagnosticCodes_ShouldReturnListOfDiagnosticCodes_WhenTheResponseIsMultipleLinesOfCodes()
        {
            _deviceMock.Setup(m => m.Query(It.IsAny<string>())).Returns("43 01 03 01 04 01 05\r\n41 01 06 01 07 01 08");

            var expected = new List<DiagnosticTroubleCode>
            {
                new() { Code = "P0103", System = "Powertrain", Subsystem = "Fuel and air metering", Description = "Mass or Volume Air Flow Circuit High Input" },
                new() { Code = "P0104", System = "Powertrain", Subsystem = "Fuel and air metering", Description = "Mass or Volume Air Flow Circuit Intermittent" },
                new() { Code = "P0105", System = "Powertrain", Subsystem = "Fuel and air metering", Description = "Manifold Absolute Pressure/Barometric Pressure Circuit Malfunction" },
                new() { Code = "P0106", System = "Powertrain", Subsystem = "Fuel and air metering", Description = "Manifold Absolute Pressure/Barometric Pressure Circuit Range/Performance Problem" },
                new() { Code = "P0107", System = "Powertrain", Subsystem = "Fuel and air metering", Description = "Manifold Absolute Pressure/Barometric Pressure Circuit Low Input" },
                new() { Code = "P0108", System = "Powertrain", Subsystem = "Fuel and air metering", Description = "Manifold Absolute Pressure/Barometric Pressure Circuit High Input" }
            };

            var sut = new DiagnosticTroubleCodeHandler(_deviceMock.Object);
            var result = sut.GetReportedDiagnosticTroubleCodes();

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetReportedDiagnosticCodes_ShouldDecodAllSystemFaultTypes_WhenTheResponseContainsAllSystemFaultTypes()
        {
            _deviceMock.Setup(m => m.Query(It.IsAny<string>()))
                .Returns("43 00 11 10 11 20 11\r\n43 30 11 40 11 50 11\r\n43 60 11 70 11 80 11\r\n43 90 11 A0 11 B0 11\r\n43 C0 11 D0 11 E0 11\r\n43 F0 11 00 00 00 00");

            var unavailableDescription = "Not available - check your vehicle manual or contact the manufacturer.";
            var expected = new List<DiagnosticTroubleCode>
            {
                new() { Code = "P0011", System = "Powertrain", Subsystem = "Fuel and air metering and auxiliary emission controls", Description = unavailableDescription },
                new() { Code = "P1011", System = "Powertrain", Subsystem = "", Description = unavailableDescription },
                new() { Code = "P2011", System = "Powertrain", Subsystem = "", Description = unavailableDescription },
                new() { Code = "P3011", System = "Powertrain", Subsystem = "", Description = unavailableDescription },
                new() { Code = "C0011", System = "Chassis", Subsystem = "Fuel and air metering and auxiliary emission controls", Description = unavailableDescription },
                new() { Code = "C1011", System = "Chassis", Subsystem = "", Description = unavailableDescription },
                new() { Code = "C2011", System = "Chassis", Subsystem = "", Description = unavailableDescription },
                new() { Code = "C3011", System = "Chassis", Subsystem = "", Description = unavailableDescription },
                new() { Code = "B0011", System = "Body", Subsystem = "Fuel and air metering and auxiliary emission controls", Description = unavailableDescription },
                new() { Code = "B1011", System = "Body", Subsystem = "", Description = unavailableDescription },
                new() { Code = "B2011", System = "Body", Subsystem = "", Description = unavailableDescription },
                new() { Code = "B3011", System = "Body", Subsystem = "", Description = unavailableDescription },
                new() { Code = "U0011", System = "Network", Subsystem = "Fuel and air metering and auxiliary emission controls", Description = unavailableDescription },
                new() { Code = "U1011", System = "Network", Subsystem = "", Description = "SCP (J1850) Invalid or Missing Data for Engine Air Intake" },
                new() { Code = "U2011", System = "Network", Subsystem = "", Description = "Module Transmitted Invalid Data (Non SCP)" },
                new() { Code = "U3011", System = "Network", Subsystem = "", Description = unavailableDescription }
            };

            var sut = new DiagnosticTroubleCodeHandler(_deviceMock.Object);
            var result = sut.GetReportedDiagnosticTroubleCodes();

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetReportedDiagnosticCodes_ShouldDecodAllSubSystemFaultTypes_WhenTheResponseContainsAllSubSystemFaultTypes()
        {
            _deviceMock.Setup(m => m.Query(It.IsAny<string>()))
                .Returns("43 00 11 01 11 02 11\r\n43 03 11 04 11 05 11\r\n43 06 11 07 11 08 11\r\n43 09 11 00 00 00 00");

            var unavailableDescription = "Not available - check your vehicle manual or contact the manufacturer.";
            var expected = new List<DiagnosticTroubleCode>
            {
                new() { Code = "P0011", System = "Powertrain", Subsystem = "Fuel and air metering and auxiliary emission controls", Description = unavailableDescription },
                new() { Code = "P0111", System = "Powertrain", Subsystem = "Fuel and air metering", Description = "Intake Air Temperature Circuit Range/Performance Problem" },
                new() { Code = "P0211", System = "Powertrain", Subsystem = "Fuel and air metering injection system", Description = "Injector Circuit Malfunction - Cylinder 10" },
                new() { Code = "P0311", System = "Powertrain", Subsystem = "Ignition systems", Description = "Cylinder 10 Misfire Detected" },
                new() { Code = "P0411", System = "Powertrain", Subsystem = "Emissions system", Description = "Secondary Air Injection System Malfunction" },
                new() { Code = "P0511", System = "Powertrain", Subsystem = "Vehicle speed controls and idle control system", Description = unavailableDescription },
                new() { Code = "P0611", System = "Powertrain", Subsystem = "Computer output circuit", Description = unavailableDescription },
                new() { Code = "P0711", System = "Powertrain", Subsystem = "Transmission", Description = "Transmission Fluid Temperature Sensor Circuit Malfunction" },
                new() { Code = "P0811", System = "Powertrain", Subsystem = "Transmission", Description = unavailableDescription },
                new() { Code = "P0911", System = "Powertrain", Subsystem = "", Description = unavailableDescription },
            };

            var sut = new DiagnosticTroubleCodeHandler(_deviceMock.Object);
            var result = sut.GetReportedDiagnosticTroubleCodes();

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetFreezeFrameDiagnosticTroubleCode_ShouldReturnDecodedDiagnosticCode()
        {
            _deviceMock.Setup(m => m.Query(It.IsAny<string>()))
                .Returns("42 02 01 11");

            var expected = new DiagnosticTroubleCode()
            {
                Code = "P0111",
                System = "Powertrain",
                Subsystem = "Fuel and air metering",
                Description = "Intake Air Temperature Circuit Range/Performance Problem"
            };

            var sut = new DiagnosticTroubleCodeHandler(_deviceMock.Object);
            var result = sut.GetFreezeFrameDiagnosticTroubleCode();

            result.Should().BeEquivalentTo(expected);
        }
    }
}
