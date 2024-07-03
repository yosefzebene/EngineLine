using EngineLine.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineLineTests.ExceptionsTests
{
    public class VehicleDataExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetMessageToDefault_WhenNoArgumentsAreProvided()
        {
            var sut = new VehicleDataException();

            sut.Message.Should().Be("There was a problem with the data received from the vehicle");
        }

        [Fact]
        public void Constructor_ShouldSetMessage_WhenMessageIsProvided()
        {
            var message = "Some message";
            var sut = new VehicleDataException(message);

            sut.Message.Should().Be(message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenMessageAndInnerExceptionAreProvided()
        {
            var message = "Some message";
            var innerException = new Exception();
            var sut = new VehicleDataException(message, innerException);

            sut.Message.Should().Be(message);
            sut.InnerException.Should().Be(innerException);
        }
    }
}
