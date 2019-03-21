using Singleton;
using Xunit;

namespace Tests
{
    internal class BasicLoggerSteps
    {
        private const string MESSAGE_TO_LOG = "TestMessage123#%";
        private const string EXPECTED_MESSAGE = "TestMessage123#%\r\n";

        private const string MULTI_MESSAGE1 = "TestMessage1!";
        private const string MULTI_MESSAGE2 = "2TestMessage&";
        private const string MULTI_MESSAGE3 = "Test_3Message^^";
        private const string MULTI_EXPECTED_MESSAGE = "TestMessage1!\r\n2TestMessage&\r\nTest_3Message^^\r\n";

        public void GivenAnEmptyLogger()
        {
            BasicLogger.Instance.Reset();
        }

        public void WhenILogAMessage()
        {
            BasicLogger.Instance.Log(MESSAGE_TO_LOG);
        }

        public void WhenILogAFewMessages()
        {
            BasicLogger.Instance.Log(MULTI_MESSAGE1);
            BasicLogger.Instance.Log(MULTI_MESSAGE2);
            BasicLogger.Instance.Log(MULTI_MESSAGE3);
        }

        public void ThenTheLoggerHasNoMessagesLogged()
        {
            Assert.Equal(string.Empty, BasicLogger.Instance.ShowLog());
        }

        public void ThenThisMessageIsLoggedSuccessfully()
        {
            Assert.Equal(EXPECTED_MESSAGE, BasicLogger.Instance.ShowLog());
        }

        public void ThenTheseMessagesAreLoggedSuccessfully()
        {
            Assert.Equal(MULTI_EXPECTED_MESSAGE, BasicLogger.Instance.ShowLog());
        }
    }
}
