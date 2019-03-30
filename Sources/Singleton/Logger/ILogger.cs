namespace Singleton.Logger
{
    /// <summary>
    /// Persists messages logged during the execution of this application.
    /// </summary>
    public interface ILogger
    {
        void Log(string message);
        string ShowLog();
        void Reset();
    }
}
