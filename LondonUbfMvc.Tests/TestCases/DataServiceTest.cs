using System;
using System.Linq;
using LondonUbfWeb.Domain.Models;
using Norm;
using NUnit.Framework;
using LondonUbfWeb.Domain.Services;

namespace LondonUbfWeb.Test.TestCases
{
    [TestFixture]
    public class DataServiceTest
    {
        private DataService _dataService;

            [SetUp]
        public void SetUp()
        {
            _dataService = new DataService();
        }

        [Test]
        public void AddJob_Should_Add_a_Job()
        {
            //arrange
            var job = new Job
                          {
                              CreateDate = DateTime.Now,
                              Date = DateTime.Now,
                              Reader = new Person {Email = "reader@gmail.com", Firstname = "reader"},
                              Messenger = new Person {Email = "andrew.chaa@yahoo.co.uk", Firstname = "Ian"},
                              PrayerServantMan = new Person {Email = "p.servant@gmail.com", Firstname = "Caleb"},
                              PrayerServantWoman = new Person {Email = "p.womanservant@gmail.com", Firstname = "Sue"}
                          };

            //act
            _dataService.AddJob(job);

            //assert
            var result = _dataService.FindJob(job.Id);
            Assert.That(result.Reader.Firstname, Is.EqualTo("reader"));

            //clean up
            _dataService.DeleteJob(job.Id);
            Assert.That(_dataService.FindJob(job.Id), Is.Null);
        }

        [Test]
        public void FindJobs_Should_Return_All_Jobs()
        {
            //arrange
            //act
            var jobs = _dataService.FindJobsForService();

            //assert
            Assert.That(jobs.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void FindJobs_Given_Date_Should_Return_Jobs_Created_On_The_Day()
        {
            //arrange
            var today = DateTime.Today;

            //act
            var jobs = _dataService.FindJobsByCreateDate(today);

            //assert
            Assert.That(jobs.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void FindJobs_Should_Return_Jobs_Without_Null_Properties()
        {
            //arrange
            //act
            var jobs = _dataService.FindJobsForService();
            
            //assert
            Assert.That(jobs.First().Messenger, Is.Not.Null);
            Assert.That(jobs.First().Presider, Is.Not.Null);
            Assert.That(jobs.First().Reader, Is.Not.Null);
            Assert.That(jobs.First().ReflectionSharer, Is.Not.Null);
        }

        [Test]
        public void AddPerson_Should_Add_Person()
        {
            //arrange
            var personToAdd = new Person
            {
                Email = "andrew.chaa@yahoo.co.uk",
                Firstname = "Andrew",
                Lastname = "Chaa",
                Mobile = "07590 536154"
            };

            //act
            var id = _dataService.AddPerson(personToAdd);

            //assert
            var person = _dataService.FindPerson(id);
            Assert.That(person.Email, Is.EqualTo("andrew.chaa@yahoo.co.uk"));

            //clean up
            _dataService.DeletePerson(person.Id);
        }

        [Test]
        public void EditPerson_Should_Update_The_Person()
        {
            //arrange
            var id = new ObjectId("66e5a204767f7be404010000");
            var personToUpdate = _dataService.FindPerson(id);
            personToUpdate.Firstname = "Sue";

            //act
            _dataService.UpdatePerson(personToUpdate);

            //assert
            var person = _dataService.FindPerson(id);
            Assert.That(person.Firstname, Is.EqualTo("Sue"));

            //clean up
            person.Firstname = "Susanna";
            _dataService.UpdatePerson(person);
        }

        [Test]
        public void FindPersons_Should_Return_List_Of_Person()
        {
            //arrange
            //act
            var persons = _dataService.FindPersons();

            //assert
            Assert.That(persons.Count(), Is.GreaterThan(0));
        }

    }

}
