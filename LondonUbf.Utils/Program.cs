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
            if (args.Count() == 0)
            {
                Console.WriteLine("Example: LondonUbf.Util.exe 2012");
                return;
            }

            _parser = new FileContentParser();
            int year = int.Parse(args[0]);

            var files = new DirectoryInfo(@"c:\temp").GetFiles();

            foreach (var file in files)
            {
                string content = File.ReadAllText(file.FullName);

                var message = _parser.Parse(content);

                string fileName = string.Format("c:\\temp\\{0} {1} {2} {3} {4}", year, message.Book, message.LectureNo, 
                    message.Chapter.Replace(':', '.'), message.Title);
                File.WriteAllText(fileName, content);
            }
        }
    }
}
