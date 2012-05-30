using System.ComponentModel;
using System.Text.RegularExpressions;

namespace LondonUbfWeb.Domain.Models
{
    public class LectureViewModel : ViewModel
    {
        public string Id { get; set; }
        
        [DisplayName("Book")]
        public string BookName { get; set; }

        [DisplayName("Passage")]
        public string BiblePassage { get; set; }

        public string ContentHtml { get; set; }
        public string DeliveryDate { get; set; }
        public string KeyVerse { get; set; }

        [DisplayName("No.")]
        public int LectureNo { get; set; }

        public int Year { get; set; }
        public string Title { get; set; }
        public string SeoTitle
        {
            get
            {
                return Regex.Replace(Title, "[^A-Z0-9a-z ]", string.Empty).Replace(" ", "-");
            }
        }

    }
}