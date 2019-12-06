namespace ConfigCat.Client.Serilog
{
    public class SerilogLogger : ILogger
    {
        private readonly string _LoggerName;

        public LogLevel LogLevel { get; set; }

        public SerilogLogger(LogLevel minLogLevel, string loggerName = null)
        {
            _LoggerName = loggerName;
            LogLevel = minLogLevel;
        }

        public void Debug(string message)
        {
            global::Serilog.Log.Debug(FormatMessage(LogLevel.Debug, message));
        }

        public void Information(string message)
        {
            global::Serilog.Log.Information(FormatMessage(LogLevel.Info, message));
        }

        public void Warning(string message)
        {
            global::Serilog.Log.Warning(FormatMessage(LogLevel.Warning, message));
        }

        public void Error(string message)
        {
            global::Serilog.Log.Error(FormatMessage(LogLevel.Error, message));
        }

        protected virtual string FormatMessage(LogLevel logLevel, string message) => $"{_LoggerName ?? "ConfigCat"} - {message}";
    }
}
