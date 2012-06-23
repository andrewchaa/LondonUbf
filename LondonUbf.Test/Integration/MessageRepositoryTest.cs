using System;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using LondonUbf.Domain;
using LondonUbf.Domain.Repositories;
using NUnit.Framework;

namespace LondonUbf.Test.Integration
{
    [TestFixture]
    public class MessageRepositoryTest
    {
        private IMessageRepository _repository;
        const string MessagePath = @".\TestData";


        [SetUp]
        public void BeforeEachTest()
        {
            _repository = new MessageRepository(new FileNameParser(), MessagePath);
        }

        [Test]
        public void Should_List_Files_In_The_Message_Directory()
        {
            var messages = _repository.FindAllMessages();

            Assert.That(messages.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Should_Filter_Messages_By_Book()
        {
            var messages = _repository.FindMessagesBy("Genesis");

            Assert.That(messages.Count(), Is.GreaterThan(0));
            Assert.That(messages.Any(m => m.Book != "Genesis"), Is.False);
        }

        [Test]
        public void Should_List_Books_Out_Of_Messages()
        {
            var books = _repository.FindAllBooks();

            Assert.That(books.First().Name, Is.EqualTo("1John"));
        }

        [Test]
        public void Should_Fine_A_Message_By_File_Name_As_Id()
        {
            var message = _repository.Find("2012 Genesis 1 1.1-1.25 In The Beginning");

            Assert.That(message.Chapter, Is.EqualTo("1:1-1:25"));
            Assert.That(message.Content.Length, Is.GreaterThan(0));
        }

    }
}
