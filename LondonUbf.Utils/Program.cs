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
                if (message.Year == 0)
                {
                    File.WriteAllText("c:\\temp\\failed_" + file.Name, string.Empty);
                    continue;
                }

                WriteMesaageFile(content, message);
            }
        }

        private static void WriteMesaageFile(string content, ServiceMessage message)
        {
            string fileName = string.Format("c:\\temp\\{0} {1} {2} {3} {4}", message.Year, message.Book, message.LectureNo,
                                            message.Chapter.Replace(':', '.'), message.Title);
            File.WriteAllText(fileName, content);
        }
    }
}
