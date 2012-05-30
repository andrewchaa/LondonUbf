using System;
using System.Collections.Generic;
using Norm;

namespace LondonUbfWeb.Domain.Models
{
    public class Job
    {
        public Job()
        {
            CBFMessenger = new List<Person>();
            Messenger = new Person();
            PrayerServantMan = new Person();
            PrayerServantWoman = new Person();
            Presider = new Person();
            Reader = new Person();
            ReflectionSharer = new Person();
        }

        [MongoIdentifier]
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Person> CBFMessenger { get; set; }
        public JobType JobType { get; set; }
        public Person Messenger { get; set; }
        public Person PrayerServantMan { get; set; }
        public Person PrayerServantWoman { get; set; }
        public Person Presider { get; set; }
        public Person Reader { get; set; }
        public Person ReflectionSharer { get; set; }
    }
}