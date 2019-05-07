using Singleton.Logger;
using Tests.TestData.Singleton;
using Xunit;

namespace Tests.Steps.Singleton
{
    /// <summary>
    /// Encapsulates reusable test operations on various interpretation of the Singleton.
    /// Please note that the tested ILogger instance is injected as an operation argument.
    /// </summary>
    internal class LoggerSteps
    {
        private class TestTimelyOperation
        {
            public ILogger Logger { get; }
            public string Identifier { get; }
            public int NumberOfOperations { get; }

            public TestTimelyOperation(ILogger logger, string identifier, int numberOfOperations)
            {
                Logger = logger;
                Identifier = identifier;
                NumberOfOperations = numberOfOperations;
            }
        }

        public void GivenAnEmptyLogger(ILogger logger)
        {
            logger.Reset();
        }

        public void WhenILogAMessage(ILogger logger)
        {
            logger.Log(TestData.Singleton.TestData.MESSAGE_TO_LOG);
        }

        public void WhenILogAFewMessages(ILogger logger)
        {
            logger.Log(TestData.Singleton.TestData.MULTI_MESSAGE1);
            logger.Log(TestData.Singleton.TestData.MULTI_MESSAGE2);
            logger.Log(TestData.Singleton.TestData.MULTI_MESSAGE3);
        }

        public void ThenThisLoggerHasNoMessagesLogged(ILogger logger)
        {
            Assert.Equal(string.Empty, logger.ShowLog());
        }

        public void ThenThisMessageIsLoggedSuccessfully(ILogger logger)
        {
            Assert.Equal(TestData.Singleton.TestData.EXPECTED_MESSAGE, logger.ShowLog());
        }

        public void ThenTheseMessagesAreLoggedSuccessfully(ILogger logger)
        {
            Assert.Equal(TestData.Singleton.TestData.MULTI_EXPECTED_MESSAGE, logger.ShowLog());
        }
    }
}
