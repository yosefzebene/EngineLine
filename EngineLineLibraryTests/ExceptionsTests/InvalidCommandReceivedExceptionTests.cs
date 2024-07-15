using EngineLineLibrary.Exceptions;
using FluentAssertions;

namespace EngineLineTests.ExceptionsTests
{
    public class InvalidCommandReceivedExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetMessageToDefault_WhenNoArgumentsAreProvided()
        {
            var sut = new InvalidCommandReceivedException();

            sut.Message.Should().Be("The command is not valid");
        }

        [Fact]
        public void Constructor_ShouldSetMessage_WhenMessageIsProvided()
        {
            var message = "Test message";
            var sut = new InvalidCommandReceivedException(message);

            sut.Message.Should().Be(message);
        }

        [Fact]
        public void Constructor_ShouldSetMessageAndInnerExecption_WhenMessageAndInnerExceptionAreProvided()
        {
            var innerException = new Exception();
            var message = "Test message";

            var sut = new InvalidCommandReceivedException(message, innerException);

            sut.Message.Should().Be(message);
            sut.InnerException.Should().Be(innerException);
        }
    }
}
