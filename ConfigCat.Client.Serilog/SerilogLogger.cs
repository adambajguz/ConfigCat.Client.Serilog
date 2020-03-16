﻿namespace ConfigCat.Client.Serilog
{
    using System;

    public sealed class SerilogLogger : ILogger
    {
        public string LoggerName { get; }
        public Func<LogLevel, string, string, string> FormatMessage { private get; set; }
        public LogLevel LogLevel { get; set; }

        public SerilogLogger(LogLevel minLogLevel = LogLevel.Warning, string loggerName = null, Func<LogLevel, string, string, string> formatMessage = null)
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
                global::Serilog.Log.Debug(FormatMessage?.Invoke(LogLevel.Debug, LoggerName, message));
        }

        public void Information(string message)
        {
            if (LogLevel >= LogLevel.Info)
                global::Serilog.Log.Information(FormatMessage?.Invoke(LogLevel.Info, LoggerName, message));
        }

        public void Warning(string message)
        {
            if (LogLevel >= LogLevel.Warning)
                global::Serilog.Log.Warning(FormatMessage?.Invoke(LogLevel.Warning, LoggerName, message));
        }

        public void Error(string message)
        {
            if (LogLevel >= LogLevel.Error)
                global::Serilog.Log.Error(FormatMessage?.Invoke(LogLevel.Error, LoggerName, message));
        }
    }
}
