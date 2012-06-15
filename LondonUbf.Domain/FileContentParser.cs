using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace LondonUbf.Domain
{
    public class FileContentParser : IMessageParser
    {
        private readonly static Regex Chapterpattern = new Regex(@"\s(?<Chapter>[0-9:-]+?)");

        public ServiceMessage Parse(string content)
        {
            var message = new ServiceMessage();

            var lines = CleanUp(content);

            string[] yearBookLectureNoline = lines[0].Split(' ');
            message.Year = yearBookLectureNoline.Length >= 3 ? ParseInt(yearBookLectureNoline[0]) : 0;
            message.Book = yearBookLectureNoline.Length >= 3 ? yearBookLectureNoline[1] : "{Book}";
            message.LectureNo = yearBookLectureNoline.Length >= 3 ? ParseInt(yearBookLectureNoline[2]) : 0;

            message.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lines[1].Trim().ToLower());

            string[] chapterLine = lines[2].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            message.Chapter = chapterLine.Length >= 2 ? chapterLine[1] : "{Chapter}";
            
            return message;
        }

        private List<string> CleanUp(string content)
        {
            string cleanedUpContent = content.Replace("\\t", string.Empty);
            return cleanedUpContent.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(l => l.Trim().Length > 0)
                .ToList();
        }

        private int ParseInt(string input)
        {
            int value;
            int.TryParse(input, out value);
            
            return value;
        }
    }
}