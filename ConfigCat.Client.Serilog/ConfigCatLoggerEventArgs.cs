using System;

namespace ConfigCat.Client.Serilog
{
    public class ConfigCatLoggerEventArgs : EventArgs
    {
        public ILogger Logger { get; }
        public LogLevel Level { get; }
        public string Message { get; }

        internal ConfigCatLoggerEventArgs(ILogger logger, LogLevel level, string message)
        {
            Logger = logger;
            Level = level;
            Message = message;
        }
    }
}
