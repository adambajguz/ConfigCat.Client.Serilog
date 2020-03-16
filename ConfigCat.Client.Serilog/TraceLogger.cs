namespace ConfigCat.Client.Serilog
{
    using DiagTrace = System.Diagnostics.Trace;

    //TODO: Test if TraceLogger works
#warning Test if TraceLogger works
    public sealed class TraceLogger : ILogger
    {
        public string LoggerName { get; }
        public LogLevel LogLevel { get; set; }

        public TraceLogger(LogLevel minLogLevel = LogLevel.Warning, string loggerName = null)
        {
            LoggerName = loggerName ?? Constants.DEFAULT_LOGGER_NAME;
            LogLevel = minLogLevel;
        }

        public void Debug(string message)
        {
            DiagTrace.WriteIf(LogLevel >= LogLevel.Debug, message, LoggerName);
        }

        public void Information(string message)
        {
            DiagTrace.WriteIf(LogLevel >= LogLevel.Info, message, LoggerName);
        }

        public void Warning(string message)
        {
            DiagTrace.WriteIf(LogLevel >= LogLevel.Warning, message, LoggerName);
        }

        public void Error(string message)
        {
            DiagTrace.WriteIf(LogLevel >= LogLevel.Error, message, LoggerName);
        }
    }
}
