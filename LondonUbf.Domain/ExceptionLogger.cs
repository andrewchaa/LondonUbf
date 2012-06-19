using System;
using Castle.Core.Logging;

namespace LondonUbf.Domain
{
    public class ExceptionLogger
    {
        private readonly ILogger _logger;
        private TimeZoneInfo _destinationTimeZone;
        private DateTime _ukTime;

        public ExceptionLogger(ILogger logger)
        {
            _logger = logger;
            _destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
        }

        public void Log(Exception exception)
        {
            string message = string.Format("<p><strong>{0}: {1}</strong><br />{2}</p>", 
                TimeZoneInfo.ConvertTime(DateTime.Now, _destinationTimeZone), 
                exception.Message, 
                exception.StackTrace
                );
            
            _logger.Error(message);
        }

        public void Log(string log)
        {
            string message = string.Format("<p>{0}: {1}</p>", TimeZoneInfo.ConvertTime(DateTime.Now, _destinationTimeZone), log);
            _logger.Info(message);
        }
    }
}