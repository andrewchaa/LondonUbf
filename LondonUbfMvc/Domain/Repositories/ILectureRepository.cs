using System.Collections.Generic;
using System.Linq;
using LondonUbfWeb.Domain.Models;
using Norm;

namespace LondonUbfWeb.Domain.Repositories
{
    public interface ILectureRepository
    {
        void Add(Lecture lecture);
        Lecture Find(ObjectId id);
        void Delete(ObjectId id);
        IQueryable<Lecture> FindByBook(string book);
        IEnumerable<string> FindAllAvailableBooks();
    }
}