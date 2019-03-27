using Singleton.Logger;
using Tests.Steps;
using Tests.TestData;
using Xunit;

namespace Tests
{
    public class BasicLoggerTests
    {
        private readonly LoggerSteps _steps;

        public BasicLoggerTests()
        {
            _steps = new LoggerSteps();
        }

        [Theory]
        [ClassData(typeof(BasicLoggerTestData))]
        public void BasicLogger_IsEmptyAfterResetting(ILogger logger)
        {
            _steps.GivenAnEmptyLogger(logger);
            _steps.ThenThisLoggerHasNoMessagesLogged(logger);
        }

        [Theory]
        [ClassData(typeof(BasicLoggerTestData))]
        public void BasicLogger_CanLogAMessage(ILogger logger)
        {
            _steps.GivenAnEmptyLogger(logger);
            _steps.WhenILogAMessage(logger);
            _steps.ThenThisMessageIsLoggedSuccessfully(logger);
        }

        [Theory]
        [ClassData(typeof(BasicLoggerTestData))]
        public void BasicLogger_CanLogMultipleMessages(ILogger logger)
        {
            _steps.GivenAnEmptyLogger(logger);
            _steps.WhenILogAFewMessages(logger);
            _steps.ThenTheseMessagesAreLoggedSuccessfully(logger);
        }

        [Theory]
        [ClassData(typeof(BasicLoggerTestData))]
        public void BasicLogger_IsNotThreadSafe(ILogger logger)
        {
            _steps.GivenAnEmptyLogger(logger);
            _steps.WhenILogAFewMessagesFromDifferentThreads(logger);
            _steps.ThenSomeOfTheLoggedMessagesAreMissing(logger);
        }
    }
}
