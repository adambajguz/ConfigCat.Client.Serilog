# ConfigCat.Client.Serilog
Serilog integration for ConfigCat.Client - simple .NET logging with fully-structured events

![Icon](ConfigCat.Client.Serilog/ConfigCat.Client.Serilog.png)

[NuGet](https://www.nuget.org/packages/ConfigCat.Client.Serilog) | [GitHub](https://github.com/adambajguz/ConfigCat.Client.Serilog)

## Getting Started

### 1. Install the [package](https://www.nuget.org/packages/ConfigCat.Client.Serilog/) with [NuGet](http://docs.nuget.org/docs/start-here/using-the-package-manager-console) 
```PowerShell
Install-Package ConfigCat.Client.Serilog
```

### 2. Import *ConfigCat.Client.Serilog* to your application
```c#
using ConfigCat.Client.Serilog;
```

### 3. Configure
Example configuration:
```c#
LogLevel logLevel = LogLevel.Warn; // Log only WARNING and higher messages

var clientConfiguration = new AutoPollConfiguration
{
    ApiKey = "#YOUR-API-KEY#",
    LoggerFactory = new SerilogLoggerFactory(logLevel),
    PollIntervalSeconds = 5
};

IConfigCatClient client = new ConfigCatClient(clientConfiguration);
```

> Don't forget to call ```client.Dispose()``` to ensure graceful shutdown.

### 4. Useful docs
* [Serilog - Getting Started](https://github.com/serilog/serilog/wiki/Getting-Started)
* [Serilog - Configuration-Basics](https://github.com/serilog/serilog/wiki/Configuration-Basics)

* [ConfigCat - README](https://github.com/configcat/.net-sdk/blob/master/README.md)
* [ConfigCat - Getting Started](https://configcat.com/docs/getting-started/)

## Contributing
Contributions are welcome.
