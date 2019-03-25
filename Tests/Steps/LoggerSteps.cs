using Singleton.Logger;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Steps
{
    internal class LoggerSteps
    {
        private const string MESSAGE_TO_LOG = "TestMessage123#%";
        private const string EXPECTED_MESSAGE = "TestMessage123#%\r\n";
        private const int PAUSE_IN_MILISECONDS = 500;

        private const string MULTI_MESSAGE1 = "TestMessage1!";
        private const string MULTI_MESSAGE2 = "2TestMessage&";
        private const string MULTI_MESSAGE3 = "Test_3Message^^";
        private const string MULTI_EXPECTED_MESSAGE = "TestMessage1!\r\n2TestMessage&\r\nTest_3Message^^\r\n";
        private const string THREAD_SAFE_EXPECTED_LOG = 
            "Thread1: Operation #1 Completed.\r\n" +
            "Thread2: Operation #1 Completed.\r\n" +
            "Thread1: Operation #2 Completed.\r\n" +
            "Thread2: Operation #2 Completed.\r\n" +
            "Thread1: Operation #3 Completed.\r\n" +
            "Thread2: Operation #3 Completed.\r\n" +
            "Thread1: Operation #4 Completed.\r\n" +
            "Thread2: Operation #4 Completed.\r\n" +
            "Thread1: Operation #5 Completed.\r\n" +
            "Thread2: Operation #5 Completed.\r\n";

        private ILogger _singletonLogger;

        public LoggerSteps(ILogger logger)
        {
            _singletonLogger = logger;
        }

        public void GivenAnEmptyLogger()
        {
            _singletonLogger.Reset();
        }

        public void WhenILogAMessage()
        {
            _singletonLogger.Log(MESSAGE_TO_LOG);
        }

        public void WhenILogAFewMessages()
        {
            _singletonLogger.Log(MULTI_MESSAGE1);
            _singletonLogger.Log(MULTI_MESSAGE2);
            _singletonLogger.Log(MULTI_MESSAGE3);
        }

        public void WhenILogAFewMessagesFromDifferentThreads()
        {
            Task task1 = Task.Factory.StartNew(() => MockTimelyOperations("Thread1", 5));
            Task task2 = Task.Factory.StartNew(() => MockTimelyOperations("Thread2", 5));
            Task.WaitAll(task1, task2);
        }

        public void ThenTheLoggerHasNoMessagesLogged()
        {
            Assert.Equal(string.Empty, _singletonLogger.ShowLog());
        }

        public void ThenThisMessageIsLoggedSuccessfully()
        {
            Assert.Equal(EXPECTED_MESSAGE, _singletonLogger.ShowLog());
        }

        public void ThenTheseMessagesAreLoggedSuccessfully()
        {
            Assert.Equal(MULTI_EXPECTED_MESSAGE, _singletonLogger.ShowLog());
        }

        public void ThenSomeOfTheLoggedMessagesAreMissing()
        {
            string currentLog = _singletonLogger.ShowLog();
            Assert.NotEqual(THREAD_SAFE_EXPECTED_LOG, currentLog);
        }

        private void MockTimelyOperations(string identifier, int numberOfOperations)
        {
            for (int i = 1; i <= numberOfOperations; i++)
            {
                Thread.Sleep(PAUSE_IN_MILISECONDS);
                _singletonLogger.Log($"{identifier}: Operation #{i} Completed.");
            }
        }
    }
}
