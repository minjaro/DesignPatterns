using Singleton.Logger;
using Tests.TestData;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Xunit;

namespace Tests.Steps
{
    /// <summary>
    /// Encapsulates reusable test operations on various interpretation of the Singleton.
    /// Please note that the tested ILogger instance is injected as an operation argument.
    /// </summary>
    internal class LoggerSteps
    {
        private const int PAUSE_IN_MILISECONDS = 500;
        private const string TIMELY_OPERATION_ID1 = "Thread1";
        private const string TIMELY_OPERATION_ID2 = "Thread2";

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
            logger.Log(ExpectedData.MESSAGE_TO_LOG);
        }

        public void WhenILogAFewMessages(ILogger logger)
        {
            logger.Log(ExpectedData.MULTI_MESSAGE1);
            logger.Log(ExpectedData.MULTI_MESSAGE2);
            logger.Log(ExpectedData.MULTI_MESSAGE3);
        }

        public void ThenThisLoggerHasNoMessagesLogged(ILogger logger)
        {
            Assert.Equal(string.Empty, logger.ShowLog());
        }

        public void ThenThisMessageIsLoggedSuccessfully(ILogger logger)
        {
            Assert.Equal(ExpectedData.EXPECTED_MESSAGE, logger.ShowLog());
        }

        public void ThenTheseMessagesAreLoggedSuccessfully(ILogger logger)
        {
            Assert.Equal(ExpectedData.MULTI_EXPECTED_MESSAGE, logger.ShowLog());
        }
    }
}
