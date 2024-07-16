using EngineLineLibrary.Exceptions;
using FluentAssertions;

namespace EngineLineLibraryTests.ExceptionsTests
{
    public class VehicleConnectionExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetDefaultMessage_WhenNoArgumentsAreProvided()
        {
            var sut = new VehicleConnectionException();

            sut.Message.Should().Be("There was a problem with the connection to the vehicle");
        }

        [Fact]
        public void Constructor_ShouldSetMessage_WhenMessageIsProvided()
        {
            var message = "Some message";

            var sut = new VehicleConnectionException(message);

            sut.Message.Should().Be(message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerException_WhenMessageAndInnerExceptionAreProvided()
        {
            var message = "Some message";
            var innerException = new Exception();

            var sut = new VehicleConnectionException(message, innerException);

            sut.Message.Should().Be(message);
            sut.InnerException.Should().Be(innerException);
        }
    }
}
