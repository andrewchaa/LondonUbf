using System.ComponentModel;
using Norm;

namespace LondonUbfWeb.Domain.Models
{
    public class JobInput
    {
        [DisplayName("Date:")]
        public string Date { get; set; }
        public string Job { get; set; }
        public ObjectId Messenger { get; set; }
        public ObjectId Presider { get; set; }
        public ObjectId Reader { get; set; }
        public ObjectId PrayerServantMan { get; set; }
        public ObjectId PrayerServantWoman { get; set; }
    }
}