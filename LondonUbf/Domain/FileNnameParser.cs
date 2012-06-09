using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LondonUbf.Domain
{
    public class FileNameParser : IMessageParser
    {
        private readonly Regex _pattern = 
            new Regex(@"(?<Year>[0-9]+?)\s(?<Book>[0-9A-Za-z]+?)\s(?<LectureNo>[0-9]+?)\s(?<Chapter>[0-9.-]+?)\s(?<Title>.+?)\.html");

        public ServiceMessage Parse(string fileName)
        {
            
            var match = _pattern.Match(fileName);

            return new ServiceMessage
                       {
                           Year = Int32.Parse(match.Groups["Year"].Value),
                           Book = match.Groups["Book"].Value,
                           LectureNo = Int32.Parse(match.Groups["LectureNo"].Value),
                           Chapter = match.Groups["Chapter"].Value.Replace('.', ':'),
                           Title = match.Groups["Title"].Value,
                           FileName = fileName
                       };

        }
    }
}