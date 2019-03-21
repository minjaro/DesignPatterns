using Singleton.Logger;

namespace Singleton
{
    /// <summary>
    /// A basic, lazy loaded, not thread-safe version of a Singleton with a gentle touch of the decorator pattern.
    ///
    /// If you must use a Singleton, consider whether you need a thread-safe version. Maybe your application is small
    /// and simple enough, to omit these threading-related, costly operations. Or maybe you don't need a singleton at all?
    /// Because mostly singletons are just a way of beautifying the anti-pattern of global access.
    /// </summary>
    /// <remarks>Avoid using singletons, think OOP!</remarks>
    public class BasicLogger : ILogger
    {
        private static BasicLogger _instance;
        private static ILogger _logger;

        public static BasicLogger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BasicLogger();
                return _instance;
            }
        }

        private BasicLogger()
        {
            _logger = new InMemoryLogger(); // In a real world, we would use Dependency Injection.
        }

        /* NOTE Below you can find the methods that bring the actual business value to the application.
           Also please note, that you cannot call BasicLogger.Reset() directly.
           A developer that uses this Singleton is forced to call reset by: BasicLogger.Instance.Reset();
           I'm mentionig this only because you can find such examples over the internet which are simply incorrect.
        */

        public void Log(string message)
        {
            _logger.Log(message);
        }

        public string ShowLog()
        {
            return _logger.ShowLog();
        }

        public void Reset()
        {
            _logger.Reset();
        }
    }
}
