namespace ConfigCat.Client.Serilog
{
    public class SerilogLoggerFactory : ILoggerFactory
    {
        private readonly LogLevel minLogLevel;

        public SerilogLoggerFactory(LogLevel minLogLevel)
        {
            this.minLogLevel = minLogLevel;
        }

        public ILogger GetLogger(string loggerName)
        {
            return new SerilogLogger(loggerName, this.minLogLevel);
        }
    }
}
