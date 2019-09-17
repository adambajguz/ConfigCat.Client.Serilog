namespace ConfigCat.Client.Serilog
{
    public class SerilogLogger : ILogger
    {
        private readonly string _LoggerName;
        private readonly LogLevel _MinLogLevel;

        public SerilogLogger(string loggerName, LogLevel minLogLevel)
        {
            _LoggerName = loggerName;
            _MinLogLevel = minLogLevel;
        }

        public void Debug(string message)
        {
            if (TargetLogEnabled(_MinLogLevel))
                global::Serilog.Log.Debug(FormatMessage(LogLevel.Debug, message));
        }

        public void Information(string message)
        {
            if (TargetLogEnabled(_MinLogLevel))
                global::Serilog.Log.Information(FormatMessage(LogLevel.Info, message));
        }

        public void Warning(string message)
        {
            if (TargetLogEnabled(_MinLogLevel))
                global::Serilog.Log.Warning(FormatMessage(LogLevel.Warn, message));
        }

        public void Error(string message)
        {
            if (TargetLogEnabled(_MinLogLevel))
                global::Serilog.Log.Error(FormatMessage(LogLevel.Error, message));
        }

        private bool TargetLogEnabled(LogLevel targetTrace) => (byte)targetTrace <= (byte)_MinLogLevel;

        protected virtual string FormatMessage(LogLevel logLevel, string message) => $"{_LoggerName ?? ""} - {message}";
    }
}
