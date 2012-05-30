using System;
using Norm;

namespace LondonUbfWeb.Domain.Models
{
    public class Lecture
    {
        [MongoIdentifier]
        public ObjectId Id { get; set; }
        public string BookName { get; set; }
        public string Content { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string KeyVerse { get; set; }
        public int LectureNo { get; set; }
        public string BiblePassage { get; set; }
        public string[] Tags { get; set; }
        public string Title { get; set; }
    }
}