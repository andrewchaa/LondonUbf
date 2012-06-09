using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LondonUbf.Domain
{
    public class FileContentParser : IMessageParser
    {
        public ServiceMessage Parse(string content)
        {
            return new ServiceMessage();
        }
    }
}