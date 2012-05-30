using System;
using System.Linq;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Domain.Repositories;
using NUnit.Framework;

namespace LondonUbfWeb.Test.TestCases
{
    public class LectureRepositoryTest
    {
        private ILectureRepository _lectureRepository;

        [SetUp]
        public void Setup()
        {
            _lectureRepository = new LectureRepository();
        }

        [Test]
        public void ShouldAddLecture()
        {
            //arrange
            var lectureToAdd = new Lecture
            {
                BookName = "Luke",
                Content = "In last week¡¯s passage, Jesus planted great hope and vision in",
                DeliveryDate = new DateTime(2011, 3, 20),
                KeyVerse =
                    "8:30 Jesus asked him, \"What is your name?\" \"Legion,\" he replied, because many demons had gone into him.",
                LectureNo = 13,
                BiblePassage = "Luke 8:22-39",
                Title = "WHAT IS YOUR NAME?"
            };

            //act
            _lectureRepository.Add(lectureToAdd);

            //assert
            var lecture = _lectureRepository.Find(lectureToAdd.Id);

            Assert.That(lectureToAdd.Title, Is.EqualTo(lecture.Title));

            //clean up
            _lectureRepository.Delete(lecture.Id);
        }

        [Test]
        public void FindLecturesShouldReturnListOfLectures()
        {
            //arrange
            //act
            var lectures = _lectureRepository.FindByBook(string.Empty);

            //assert
            Assert.That(lectures.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void ShouldFindAllAvailableBooks()
        {
            //arrange
            //act
            var books = _lectureRepository.FindAllAvailableBooks();

            //assert
            Assert.That(books.Count(), Is.GreaterThan(0));
        }

    }
}