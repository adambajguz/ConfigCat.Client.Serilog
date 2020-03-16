namespace ConfigCat.Client.Serilog
{
    using System.Collections.Generic;

    public class LoggingChain : ILogger
    {
        protected internal List<ILogger> Loggers { get; } = new List<ILogger>();
        public LogLevel LogLevel { get; set; }

        public LoggingChain(LogLevel minLogLevel = LogLevel.Warning)
        {
            LogLevel = minLogLevel;
        }

        public void Debug(string message)
        {
            if (LogLevel >= LogLevel.Debug)
                foreach (ILogger logger in Loggers)
                    logger.Debug(message);
        }
        public void Information(string message)
        {
            if (LogLevel >= LogLevel.Info)
                foreach (ILogger logger in Loggers)
                    logger.Information(message);
        }

        public void Warning(string message)
        {
            if (LogLevel >= LogLevel.Warning)
                foreach (ILogger logger in Loggers)
                    logger.Warning(message);
        }

        public void Error(string message)
        {
            if (LogLevel >= LogLevel.Error)
                foreach (ILogger logger in Loggers)
                    logger.Error(message);
        }
    }
}
