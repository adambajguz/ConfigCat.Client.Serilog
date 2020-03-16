namespace ConfigCat.Client.Serilog
{
    using System;

    public sealed class ConsoleLogger : ILogger
    {
        public string LoggerName { get; }
        public Func<LogLevel, string, string, string> FormatMessage { private get; set; }
        public LogLevel LogLevel { get; set; }

        public ConsoleLogger(LogLevel minLogLevel = LogLevel.Warning, string loggerName = null, Func<LogLevel, string, string, string> formatMessage = null)
        {
            LoggerName = loggerName ?? Constants.DEFAULT_LOGGER_NAME;
            LogLevel = minLogLevel;

            if (formatMessage is null)
                FormatMessage = (logLevel, loggerName, message) => $"{LoggerName} - {message}";
            else
                FormatMessage = formatMessage;
        }

        public void Debug(string message)
        {
            if (LogLevel >= LogLevel.Debug)
                Console.WriteLine(FormatMessage?.Invoke(LogLevel.Debug, LoggerName, message));
        }

        public void Information(string message)
        {
            if (LogLevel >= LogLevel.Info)
                Console.WriteLine(FormatMessage?.Invoke(LogLevel.Info, LoggerName, message));
        }

        public void Warning(string message)
        {
            if (LogLevel >= LogLevel.Warning)
                Console.WriteLine(FormatMessage?.Invoke(LogLevel.Warning, LoggerName, message));
        }

        public void Error(string message)
        {
            if (LogLevel >= LogLevel.Error)
                Console.WriteLine(FormatMessage?.Invoke(LogLevel.Error, LoggerName, message));
        }
    }
}
