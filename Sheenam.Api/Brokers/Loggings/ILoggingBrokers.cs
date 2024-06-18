using System;

namespace Sheenam.Api.Brokers.Loggings
{
    public interface ILoggingBrokers
    {
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}
