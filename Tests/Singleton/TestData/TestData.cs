namespace Tests.TestData.Singleton
{
    internal static class TestData
    {
        public const string MESSAGE_TO_LOG = "TestMessage123#%";
        public const string EXPECTED_MESSAGE = "TestMessage123#%\r\n";

        public const string MULTI_MESSAGE1 = "TestMessage1!";
        public const string MULTI_MESSAGE2 = "2TestMessage&";
        public const string MULTI_MESSAGE3 = "Test_3Message^^";
        public const string MULTI_EXPECTED_MESSAGE = "TestMessage1!\r\n2TestMessage&\r\nTest_3Message^^\r\n";        
    }
}
