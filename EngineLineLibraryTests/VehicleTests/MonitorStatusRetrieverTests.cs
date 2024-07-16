using EngineLineLibrary.Connection.Devices;
using EngineLineLibrary.Vehicle;
using EngineLineLibrary.Vehicle.Models;
using FluentAssertions;
using Moq;

namespace EngineLineLibraryTests.VehicleTests
{
    public class MonitorStatusRetrieverTests
    {
        private Mock<IObd2Device> _deviceMock;

        public MonitorStatusRetrieverTests()
        {
            _deviceMock = new Mock<IObd2Device>();
        }

        [Fact]
        public void DecodeMonitorStatusPidResponse_ShouldReturnDecodedMonitorStatusData_WhenProvidedWithAValidHexArrayToDecode()
        {
            var expected = new MonitorStatus()
            {
                CheckEngineLightOn = true,
                NumberOfDtcs = 127,
                EngineType = "Spark ignition",
                ReadinessChecks = new List<ReadinessCheck>()
                {
                    new()
                    {
                        Name = "Components",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Fuel System",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Misfire",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "EGR and/or VVT System",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Oxygen Sensor Heater",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Oxygen Sensor",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Gasoline Particulate Filter",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Secondary Air System",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Evaporative System",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Heated Catalyst",
                        Available = true,
                        Incomplete = true,
                    },
                    new()
                    {
                        Name = "Catalyst",
                        Available = true,
                        Incomplete = true,
                    }
                }
            };

            _deviceMock.Setup(m => m.Query(It.IsAny<string>())).Returns("41 01 ff f7 ff ff");

            var sut = new MonitorStatusRetriever(_deviceMock.Object);
            var result = sut.GetMonitorStatus();

            result.CheckEngineLightOn.Should().Be(expected.CheckEngineLightOn);
            result.NumberOfDtcs.Should().Be(expected.NumberOfDtcs);
            result.EngineType.Should().Be(expected.EngineType);
            result.ReadinessChecks.Should().BeEquivalentTo(expected.ReadinessChecks);
        }
    }
}
