using Xunit;

namespace Tests
{
    public class BasicLoggerTests
    {
        private readonly BasicLoggerSteps _steps;

        public BasicLoggerTests()
        {
            _steps = new BasicLoggerSteps();
        }

        [Fact]
        public void BasicLogger_IsEmptyAfterResetting()
        {
            _steps.GivenAnEmptyLogger();
            _steps.ThenTheLoggerHasNoMessagesLogged();
        }

        [Fact]
        public void BasicLogger_CanLogAMessage()
        {
            _steps.GivenAnEmptyLogger();
            _steps.WhenILogAMessage();
            _steps.ThenThisMessageIsLoggedSuccessfully();
        }

        [Fact]
        public void BasicLogger_CanLogMultipleMessages()
        {
            _steps.GivenAnEmptyLogger();
            _steps.WhenILogAFewMessages();
            _steps.ThenTheseMessagesAreLoggedSuccessfully();
        }
    }
}
