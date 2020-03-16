namespace ConfigCat.Client.Serilog.Tests
{
    using System;
    using global::Serilog;
    using global::Serilog.Sinks.SystemConsole.Themes;
    using Xunit;

    public class SerilogConfigurationHelper
    {
        [Fact]
        public void Configure()
        {

            var loggerConfiguration = new LoggerConfiguration()
                                         .Enrich.FromLogContext();


            loggerConfiguration.MinimumLevel.Verbose();

            loggerConfiguration.WriteTo.Async(a => a.Logger(WriteToConsole()));


            Log.Logger = loggerConfiguration.CreateLogger();


            Log.Information("Closing web host...");

            Log.CloseAndFlush();
        }

        private static Action<LoggerConfiguration> WriteToConsole()
        {
            return b => b.WriteTo.Async(c => c.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                                                       theme: AnsiConsoleTheme.Literate));
        }
    }
}