using System.Collections.Concurrent;

namespace APICatalogo.Logging
{
    public class CustomLoggingProvider : ILoggerProvider
    {
        readonly CustomLoggerProviderConfiguration loggerConfig;

        readonly ConcurrentDictionary<string, CustomerLogger> loggers =
            new ConcurrentDictionary<string, CustomerLogger>();

        public CustomLoggingProvider(CustomLoggerProviderConfiguration config)
        {
            loggerConfig = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, loggerConfig));
        }

        public void Dispose()
        {
            loggers.Clear();
        }
    }
}
