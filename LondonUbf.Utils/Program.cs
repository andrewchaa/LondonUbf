using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LondonUbf.Domain;

namespace LondonUbf.Utils
{
    class Program
    {
        private static IMessageParser _parser;

        static void Main(string[] args)
        {
            _parser = new FileContentParser();

            var files = new DirectoryInfo(@"c:\temp").GetFiles();

            foreach (var file in files)
            {
                string content = File.ReadAllText(file.FullName);

                var message = _parser.Parse(content);
                WriteMesaageFile(message, content);
            }
        }

        private static void WriteMesaageFile(ServiceMessage message, string content)
        {
            if (string.IsNullOrEmpty(message.Book))
                message.Book = "{Book}";

            if (string.IsNullOrEmpty(message.Chapter))
                message.Chapter = "{Chapter}";

            if (string.IsNullOrEmpty(message.Title))
                message.Title = "{Title}";

            string fileName = string.Format("c:\\temp\\{0} {1} {2} {3} {4}", message.Year, message.Book, message.LectureNo,
                                            CleanUpForFileName(message.Chapter), CleanUpForFileName(message.Title));
            File.WriteAllText(fileName, content);
        }

        private static string CleanUpForFileName(string input)
        {
            return input.Replace(':', '.').Replace("?", string.Empty).Replace("�", "'");

        }
    }
}
