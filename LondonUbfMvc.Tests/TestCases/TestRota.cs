using System;
using System.Collections.Generic;
using LondonUbfWeb.Domain.Models;
using NUnit.Framework;

namespace LondonUbfWeb.Test.TestCases
{
    /// <summary>
    /// Summary description for RotaTest
    /// </summary>
    [TestFixture]
    public class TestRota
    {
        [Test]
        public void Job_Properties()
        {
            //arrange
            //act
            var job = new Job
                          {
                              CreateDate = DateTime.Today,
                              JobType = JobType.Others,
                              ReflectionSharer = new Person { Email = "andrew.chaa@yahoo.co.uk", Firstname = "Andrew", Lastname = "Chaa"}
                          };

            //assert
            Assert.That(job.CreateDate, Is.EqualTo(DateTime.Today));
            Assert.That(job.ReflectionSharer.Firstname, Is.EqualTo("Andrew"));
            Assert.That(job.JobType, Is.EqualTo(JobType.Others));
        }

        [Test]
        public void List_Given_Responsibility_Should_Return_Date_Person()
        {
            //prepare
            //action
            //var rotas = _service.List("Presider");
            
            //assert
            //Assert.That(rotas.Count, Is.GreaterThan(0));
        }

        [Test]
        public void List_Rota_Should_Be_Ordered_By_Date()
        {
            //prepare
            //action
            //var rotas = _service.List("Presider");
            //var rotaOlder = rotas[1];
            //var rotaLessOld = rotas[0];

            //assert
            //Assert.That(rotaLessOld.Date, Is.GreaterThan(rotaOlder.Date));
        }

        [Test]
        public void Repository_Returns_5_Test_Rotas()
        {
            //Assert.AreEqual(10, _service.List().ToList().Count);
        }

        [Test]
        public void Repository_Returns_Rotas_To_Email()
        {
            List<Rota> emailRotas = GetRotasToEmail();
            Assert.AreEqual(5, emailRotas.Count);
        }

        [Test]
        public void Rotas_To_Email_Date_Is_Not_In_the_Past()
        {
            List<Rota> rotasToEmail = GetRotasToEmail();
            foreach (Rota rota in rotasToEmail)
            {
                Assert.IsTrue(rota.Date >= DateTime.Today);
            }
        }

        [Test]
        public void Send_Mail_To_Rotas()
        {
            //Assert.IsTrue(_service.SendMail(new List<Rota>()));
        }

        [Test]
        public void Update_Rota_After_Send_Email()
        {
            List<Rota> rotasToEmail = GetRotasToEmail();
            //RotaService rotaService = new RotaService(new StubMailService());
            //rotaService.SendMail(rotasToEmail);

            Assert.AreEqual(true, rotasToEmail[0].IsMailSent);
        }

        private List<Rota> GetRotasToEmail()
        {
            //RotaService rotaService = new RotaService(new RotaTestRepository(), new StubMailService());
            //List<Rota> emailRotas = rotaService.ListRotasToMail().ToList<Rota>();
            //return emailRotas;
            return new List<Rota>();
        }

    }
}
