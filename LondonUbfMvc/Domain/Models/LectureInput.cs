using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LondonUbfWeb.Domain.Models
{
    public class LectureInput
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Passage:")]
        public string BiblePassage { get; set; }

        [Required]
        [DisplayName("Lecture:")]
        public string BookName { get; set; }

        [Required]
        [DisplayName("Main content:")]
        public string Content { get; set; }

        [DisplayName("Delivered on:")]
        public string DeliveryDate { get; set; }
        public string IsoDeliveryDate { get; set; }

        [Required]
        [DisplayName("Key verse:")]
        public string KeyVerse { get; set; }

        [Required]
        [DisplayName("Lecture no:")]
        public string LectureNo { get; set; }

        [DisplayName("Tags:")]
        public string[] Tags { get; set; }

        [Required]
        [DisplayName("Title:")]
        public string Title { get; set; }

        public string SubmitButtonText { get; set; }
        
        public string ContentNoHtml     
        {
            get 
            { 
                var regex = new Regex("<[^>]*>");
                return regex.Replace(Content, string.Empty);
            }
        }

        public Lecture ToLecture()
        {
            var lecture = new Lecture
            {
                BiblePassage = BiblePassage.TrimEnd(),
                BookName = BookName.TrimEnd(),
                Content = ContentNoHtml.TrimEnd(),
                DeliveryDate = DateTime.Parse(DeliveryDate),
                KeyVerse = KeyVerse.Trim(),
                LectureNo = int.Parse(LectureNo),
                Title = Title
            };

            return lecture;
        }

    }
}