using System;
using System.Text.RegularExpressions;

namespace LondonUbf.Domain
{
    public class ServiceMessage
    {
        public string Book { get; set; }
        public int LectureNo { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Chapter { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }

        public static ServiceMessage From(string fileName)
        {
            var pattern = new Regex(@"(?<Year>[0-9]+?)\s(?<Book>[0-9A-Za-z]+?)\s(?<LectureNo>[0-9]+?)\s(?<Chapter>[0-9.-]+?)\s(?<Title>.+?)\.json");
            var match = pattern.Match(fileName);

            return new ServiceMessage
                       {
                           Year = int.Parse(match.Groups["Year"].Value),
                           Book = match.Groups["Book"].Value,
                           LectureNo = int.Parse(match.Groups["LectureNo"].Value),
                           Chapter = match.Groups["Chapter"].Value,
                           Title = match.Groups["Title"].Value,
                           FileName = fileName
                       };

        }
    }
}