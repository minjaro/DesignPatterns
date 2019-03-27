using Singleton.Logger;

namespace Singleton
{
    /// <summary>
    /// This variant of a singleton is not lazy loaded, but thread safe.
    /// </summary>
    public class StaticLogger : ILogger
    {
        public static StaticLogger Instance { get; } = new StaticLogger();

        private static ILogger _logger;

        private StaticLogger()
        {
            _logger = new InMemoryLogger(); // In a real world, we would use Dependency Injection.
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }

        public void Reset()
        {
            _logger.Reset();
        }

        public string ShowLog()
        {
            return _logger.ShowLog();
        }
    }
}
