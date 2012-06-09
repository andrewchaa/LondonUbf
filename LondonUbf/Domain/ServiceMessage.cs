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

        public string ContentHtml
        {
            get { return Content.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("�", string.Empty); }
        }

    }
}