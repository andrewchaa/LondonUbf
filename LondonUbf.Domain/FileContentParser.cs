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
            var lines = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (!YearBookLectureNopattern.IsMatch(lines[0]))
                return new ServiceMessage();

            var message = new ServiceMessage();
            var bookLectureNoMatch = YearBookLectureNopattern.Match(lines[0]);
            message.Year = int.Parse(bookLectureNoMatch.Groups["Year"].Value);
            message.Book = bookLectureNoMatch.Groups["Book"].Value;
            message.LectureNo = int.Parse(bookLectureNoMatch.Groups["LectureNo"].Value);

            message.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lines[1].ToLower());

            var chapterMatch = Chapterpattern.Match(lines[2]);
            message.Chapter = chapterMatch.Groups["Chapter"].Value;

            return message;
        }
    }
}