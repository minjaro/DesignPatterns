namespace Tests
{
    internal static class ExpectedData
    {
        public const string MESSAGE_TO_LOG = "TestMessage123#%";
        public const string EXPECTED_MESSAGE = "TestMessage123#%\r\n";

        public const string MULTI_MESSAGE1 = "TestMessage1!";
        public const string MULTI_MESSAGE2 = "2TestMessage&";
        public const string MULTI_MESSAGE3 = "Test_3Message^^";
        public const string MULTI_EXPECTED_MESSAGE = "TestMessage1!\r\n2TestMessage&\r\nTest_3Message^^\r\n";
        public const string THREAD_SAFE_EXPECTED_LOG =
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
    }
}
