namespace ConfigCat.Client.Serilog
{
    using System;

    public sealed class EventLogger : ILogger
    {
        public string LoggerName { get; }
        public LogLevel LogLevel { get; set; }

        //TODO: Add message type, messgae params, and events for diffferent messages like: $"Evaluating '{key}' failed. Returning default value: '{defaultValue}'. Here are the available keys: {keys}."
        public event EventHandler<ConfigCatLoggerEventArgs> LoggerInvoked;
        public event EventHandler<ConfigCatLoggerEventArgs> DebugInvoked;
        public event EventHandler<ConfigCatLoggerEventArgs> InformationInvoked;
        public event EventHandler<ConfigCatLoggerEventArgs> WarningInvoked;
        public event EventHandler<ConfigCatLoggerEventArgs> ErrorInvoked;

        public EventLogger(LogLevel minLogLevel = LogLevel.Warning, string loggerName = null)
        {
            LoggerName = loggerName ?? Constants.DEFAULT_LOGGER_NAME;
            LogLevel = minLogLevel;
        }

        public void Debug(string message)
        {
            if (LogLevel >= LogLevel.Debug)
            {
                ConfigCatLoggerEventArgs e = new ConfigCatLoggerEventArgs(this, LogLevel.Debug, message);
                LoggerInvoked?.Invoke(this, e);
                DebugInvoked?.Invoke(this, e);
            }
        }

        public void Information(string message)
        {
            if (LogLevel >= LogLevel.Info)
            {
                ConfigCatLoggerEventArgs e = new ConfigCatLoggerEventArgs(this, LogLevel.Debug, message);
                LoggerInvoked?.Invoke(this, e);
                InformationInvoked?.Invoke(this, e);
            }
        }

        public void Warning(string message)
        {
            if (LogLevel >= LogLevel.Warning)
            {
                ConfigCatLoggerEventArgs e = new ConfigCatLoggerEventArgs(this, LogLevel.Debug, message);
                LoggerInvoked?.Invoke(this, e);
                WarningInvoked?.Invoke(this, e);
            }
        }

        public void Error(string message)
        {
            if (LogLevel >= LogLevel.Error)
            {
                ConfigCatLoggerEventArgs e = new ConfigCatLoggerEventArgs(this, LogLevel.Debug, message);
                LoggerInvoked?.Invoke(this, e);
                ErrorInvoked?.Invoke(this, e);
            }
        }
    }
}
