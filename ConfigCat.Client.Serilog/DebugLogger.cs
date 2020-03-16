namespace ConfigCat.Client.Serilog
{
    using DiagDebug = System.Diagnostics.Debug;

    //TODO: Test if DebugLogger works
#warning Test if DebugLogger works
    public sealed class DebugLogger : ILogger
    {
        public string LoggerName { get; }
        public LogLevel LogLevel { get; set; }

        public DebugLogger(LogLevel minLogLevel = LogLevel.Warning, string loggerName = null)
        {
            LoggerName = loggerName ?? Constants.DEFAULT_LOGGER_NAME;
            LogLevel = minLogLevel;
        }

        public void Debug(string message)
        {
            DiagDebug.WriteIf(LogLevel >= LogLevel.Debug, message, LoggerName);
        }

        public void Information(string message)
        {
            DiagDebug.WriteIf(LogLevel >= LogLevel.Info, message, LoggerName);
        }

        public void Warning(string message)
        {
            DiagDebug.WriteIf(LogLevel >= LogLevel.Warning, message, LoggerName);
        }

        public void Error(string message)
        {
            DiagDebug.WriteIf(LogLevel >= LogLevel.Error, message, LoggerName);
        }
    }
}
