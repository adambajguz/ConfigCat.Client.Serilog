namespace ConfigCat.Client.Serilog
{
    public class SerilogLogger : ILogger
    {
        private readonly string _LoggerName;

        public LogLevel LogLevel { get; set; }

        public SerilogLogger(string loggerName, LogLevel minLogLevel)
        {
            _LoggerName = loggerName;
            LogLevel = minLogLevel;
        }

        public void Debug(string message)
        {
            if (TargetLogEnabled(LogLevel))
                global::Serilog.Log.Debug(FormatMessage(LogLevel.Debug, message));
        }

        public void Information(string message)
        {
            if (TargetLogEnabled(LogLevel))
                global::Serilog.Log.Information(FormatMessage(LogLevel.Info, message));
        }

        public void Warning(string message)
        {
            if (TargetLogEnabled(LogLevel))
                global::Serilog.Log.Warning(FormatMessage(LogLevel.Warning, message));
        }

        public void Error(string message)
        {
            if (TargetLogEnabled(LogLevel))
                global::Serilog.Log.Error(FormatMessage(LogLevel.Error, message));
        }

        private bool TargetLogEnabled(LogLevel targetTrace) => (byte)targetTrace <= (byte)LogLevel;

        protected virtual string FormatMessage(LogLevel logLevel, string message) => $"{_LoggerName ?? ""} - {message}";
    }
}
