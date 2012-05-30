using System;
using System.Collections.Generic;
using System.Linq;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Helpers;
using Norm;

namespace LondonUbfWeb.Domain.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private const string CollectionName = "Lectures";

        public void Add(Lecture lecture)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var collection = db.GetCollection<Lecture>(CollectionName);
                collection.Save(lecture);
            }

        }

        public Lecture Find(ObjectId id)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var lecture = db.GetCollection<Lecture>(CollectionName).AsQueryable()
                    .Where(l => l.Id == id)
                    .FirstOrDefault();

                return lecture;
            }

        }

        public void Delete(ObjectId id)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var collection = db.GetCollection<Lecture>(CollectionName);
                var lecture = collection.AsQueryable()
                    .Where(l => l.Id == id)
                    .FirstOrDefault();

                collection.Delete(lecture);
            }

        }

        public IQueryable<Lecture> FindByBook(string book)
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var lectures = db.GetCollection<Lecture>("Lectures").AsQueryable()
                    .OrderBy(l => l.BookName)
                    .OrderBy(l => l.LectureNo);

                if (string.IsNullOrEmpty(book))
                    return lectures;

                return lectures.Where(l => l.BookName.ToLower() == book.ToLower());
            }
        }

        public IEnumerable<string> FindAllAvailableBooks()
        {
            using (var db = Mongo.Create(Config.MongoDbConnection))
            {
                var result = db.GetCollection<Lecture>("Lectures").Distinct<string>("BookName").OrderBy(s => s);

                return result;
            }

        }
    }
}