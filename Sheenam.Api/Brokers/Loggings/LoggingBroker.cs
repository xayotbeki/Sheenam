/*==============================
 * Copyright(c) Coalition of Good-Hearted Engineers
 * Free to Use Comfort and Peace
 =================================*/



using Microsoft.Extensions.Logging;
using System;

namespace Sheenam.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBrokers
    {
        private readonly ILogger<LoggingBroker> logger;

        public LoggingBroker(ILogger<LoggingBroker> logger) =>
            this.logger = logger;

        public void LogError(Exception exception) =>
            this.logger.LogError(exception,exception.Message);
        

        public void LogCritical(Exception exception) =>
            this.logger.LogCritical(exception,exception.Message);
        
        

    }
}
