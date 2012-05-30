using System;
using System.Collections.Generic;
using System.Linq;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Helpers;
using Norm;

namespace LondonUbfWeb.Domain.Services
{
    public class DataService
    {
        public void AddJob(Job job)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var jobs = db.GetCollection<Job>("Jobs");
                jobs.Save(job);
            }
        }

        public ObjectId AddPerson(Person person)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var persons = db.GetCollection<Person>("Persons");
                persons.Save(person);

                return person.Id;
            }
        }

        public void DeleteJob(ObjectId id)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var collection = db.GetCollection<Job>("Jobs");
                var job = collection.AsQueryable()
                    .Where(j => j.Id == id)
                    .FirstOrDefault();

                collection.Delete(job);
            }

        }

        public void DeletePerson(ObjectId id)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var collection = db.GetCollection<Person>("Persons");
                var person = collection.AsQueryable()
                    .Where(p => p.Id == id)
                    .First();

                collection.Delete(person);
            }
        }

        public Job FindJob(ObjectId id)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                return db.GetCollection<Job>("Jobs").AsQueryable()
                .Where(j => j.Id == id)
                .FirstOrDefault();
            }
        }

        public IEnumerable<Job> FindJobsForService()
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                return db.GetCollection<Job>("Jobs").AsQueryable().Where(j => j.JobType == JobType.Service).OrderByDescending(j => j.Date).ToList();
            }
        }

        public Person FindPerson(ObjectId id)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                return db.GetCollection<Person>("Persons").AsQueryable()
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Person> FindPersons()
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                return db.GetCollection<Person>("Persons").AsQueryable()
                    .OrderBy(p => p.Firstname);
            }
        }

        public IEnumerable<Job> FindJobsByCreateDate(DateTime createDate)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                return db.GetCollection<Job>("Jobs").AsQueryable()
                    .Where(j => j.CreateDate >= createDate)
                    .ToList();
            }
        }

        public void UpdatePerson(Person person)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var collection = db.GetCollection<Person>("Persons");
                collection.Save(person);

            }
        }

    }
}