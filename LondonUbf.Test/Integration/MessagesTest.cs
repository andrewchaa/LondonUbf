using System;
using System.Linq;
using System.Text;
using LondonUbf.Domain;
using NUnit.Framework;

namespace LondonUbf.Test.Integration
{
    [TestFixture]
    public class MessagesTest
    {
        [Test]
        public void Should_List_Files_In_The_Message_Directory()
        {
            const string messagePath = @"..\..\..\LondonUbf\Content\messages";
            var repository = new MessageRepository(messagePath);
            
            var messages = repository.FindAll();

            Assert.That(messages.First().FileName.Contains("\\2012 Genesis 1 1.1-1.25 In The Beginning.js"), Is.True);
            Assert.That(messages.First().Book, Is.EqualTo("Genesis"));
        }

        [Test]
        public void Chapter_Replace_Dot_To_Colon_To_Follow_The_Convention()
        {
            var message = ServiceMessage.From("\\2012 Genesis 1 1.1-1.25 In The Beginning.js");

            Assert.That(message.Chapter, Is.EqualTo("1:1-1:25"));
        }

    }
}
