namespace ConfigCat.Client.Serilog
{
    //TODO: use nullable types?
    public sealed class LoggingChainBuilder
    {
        private LoggingChain Chain { get; set; } = new LoggingChain();

        public LoggingChainBuilder()
        {

        }

        public LoggingChainBuilder SetMinimumLogLevel(LogLevel minLogLevel)
        {
            Chain.LogLevel = minLogLevel;

            return this;
        }

        public LoggingChainBuilder AddLogger<T>() 
            where T : ILogger
        {
            return this;
        }

        public LoggingChain Build()
        {
            return Chain;
        }
    }
}
