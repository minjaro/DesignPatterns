using Singleton;
using Tests.Steps;
using Xunit;

namespace Tests
{
    public class BasicLoggerTests
    {
        private readonly LoggerSteps _steps;

        public BasicLoggerTests()
        {
            _steps = new LoggerSteps(BasicLogger.Instance);
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

        [Fact]
        public void BasicLogger_IsNotThreadSafe()
        {
            _steps.GivenAnEmptyLogger();
            _steps.WhenILogAFewMessagesFromDifferentThreads();
            _steps.ThenSomeOfTheLoggedMessagesAreMissing();
        }
    }
}
