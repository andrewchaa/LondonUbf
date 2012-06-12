using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LondonUbf.Domain
{
    public class FileContentParser : IMessageParser
    {
        private readonly static Regex Chapterpattern = new Regex(@"\s(?<Chapter>[0-9:-]+?)$");

        public ServiceMessage Parse(string content)
        {
            string cleanedUpContent = content.Replace("\\t", string.Empty);

            var lines = cleanedUpContent.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var message = new ServiceMessage();

            string[] yearBookLectureNoArray = lines[0].Split(' ');
            if (yearBookLectureNoArray.Length > 2)
            {
                message.Year = ParseInt(yearBookLectureNoArray[0]);
                message.Book = yearBookLectureNoArray[1];
                message.LectureNo = ParseInt(yearBookLectureNoArray[2]);

            }
                
            message.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lines[1].Trim().ToLower());

            if (Chapterpattern.IsMatch(lines[2]))
                message.Chapter = Chapterpattern.Match(lines[2]).Groups["Chapter"].Value;

            return message;
        }

        private int ParseInt(string input)
        {
            int value;
            int.TryParse(input, out value);
            
            return value;
        }
    }
}