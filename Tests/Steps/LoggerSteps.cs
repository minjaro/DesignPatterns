using Singleton.Logger;
using System.Threading;
using System.Threading.Tasks;
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

        public void WhenILogAFewMessagesFromDifferentThreads(ILogger logger)
        {
            Task task1 = Task.Factory.StartNew(() => MockTimelyOperations(new TestTimelyOperation(logger, TIMELY_OPERATION_ID1, 5)));
            Task task2 = Task.Factory.StartNew(() => MockTimelyOperations(new TestTimelyOperation(logger, TIMELY_OPERATION_ID2, 5)));
            Task.WaitAll(task1, task2);
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

        public void ThenSomeOfTheLoggedMessagesAreMissing(ILogger logger)
        {
            string currentLog = logger.ShowLog();
            Assert.NotEqual(ExpectedData.THREAD_SAFE_EXPECTED_LOG, currentLog);
        }

        private void MockTimelyOperations(TestTimelyOperation timelyOperation)
        {
            for (int i = 1; i <= timelyOperation.NumberOfOperations; i++)
            {
                Thread.Sleep(PAUSE_IN_MILISECONDS);
                timelyOperation.Logger.Log($"{timelyOperation.Identifier}: Operation #{i} Completed.");
            }
        }
    }
}
