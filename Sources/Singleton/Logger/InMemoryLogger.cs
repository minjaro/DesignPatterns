using System.Collections.Generic;
using System.Text;

namespace Singleton.Logger
{
    /// <summary>
    /// Persists messages in the random access memory.
    /// </summary>
    internal class InMemoryLogger : ILogger
    {
        private readonly List<string> _log;

        public InMemoryLogger()
        {
            _log = new List<string>();
        }

        public void Log(string message)
        {
            _log.Add(message);
        }

        public void Reset()
        {
            _log.Clear();
        }

        public string ShowLog()
        {
            if(_log.Count < 0)
                return string.Empty;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (string message in _log)
            {
                stringBuilder.AppendLine(message);
            }

            return stringBuilder.ToString();
        }
    }
}
