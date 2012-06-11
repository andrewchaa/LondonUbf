using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LondonUbf.Domain
{
    public class FileContentParser : IMessageParser
    {
        private readonly static Regex YearBookLectureNopattern = new Regex(@"^(?<Year>[0-9]+?)\s(?<Book>[0-9A-Za-z]+?)\s(?<LectureNo>[0-9]+?)\s");
        private readonly static Regex Chapterpattern = new Regex(@"\s(?<Chapter>[0-9:-]+?)$");

        public ServiceMessage Parse(string content)
        {
            string cleanedUpContent = content.Replace("\\t", string.Empty);

            var lines = cleanedUpContent.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var message = new ServiceMessage();

            if (YearBookLectureNopattern.IsMatch(lines[0]))
            {
                message.Year = int.Parse(YearBookLectureNopattern.Match(lines[0]).Groups["Year"].Value);
                message.Book = YearBookLectureNopattern.Match(lines[0]).Groups["Book"].Value;
                message.LectureNo = int.Parse(YearBookLectureNopattern.Match(lines[0]).Groups["LectureNo"].Value);
            }
                
            message.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lines[1].Trim().ToLower());

            if (Chapterpattern.IsMatch(lines[2]))
                message.Chapter = Chapterpattern.Match(lines[2]).Groups["Chapter"].Value;

            return message;
        }
    }
}