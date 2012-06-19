using System;
using Castle.Core.Logging;

namespace LondonUbf.Domain
{
    public class ExceptionLogger
    {
        private readonly ILogger _logger;

        public ExceptionLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(Exception exception)
        {
            var ukTimeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var time = TimeZoneInfo.ConvertTime(DateTime.Now, ukTimeZone);
            string message = string.Format("<p><strong>{0}: {1}</strong><br />{2}</p>", time, exception.Message, exception.StackTrace);
            _logger.Error(message);
        }
    }
}