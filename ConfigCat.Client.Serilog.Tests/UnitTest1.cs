namespace ConfigCat.Client.Serilog.Tests
{
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //TODO: think how to write tests 
            DebugLogger a = new DebugLogger(LogLevel.Debug);
            a.Error("test");

            TraceLogger b = new TraceLogger(LogLevel.Debug);
            b.Error("test");   
            
            ConsoleLogger c = new ConsoleLogger(LogLevel.Debug);
            c.Error("test");
        }
    }
}
