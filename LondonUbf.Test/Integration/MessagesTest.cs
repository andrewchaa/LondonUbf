using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace LondonUbf.Test.Integration
{
    [TestFixture]
    public class MessagesTest
    {
        [Test]
        public void Should_List_Files_In_The_Message_Directory()
        {
            var repository = new MessageRepository();
            

            var directory = new DirectoryInfo(@"C:\Users\Andrew\Projects\LondonUbf\LondonUbf\Content\messages");
            var files = directory.GetFiles();

            Assert.That(files.First().Name, Is.EqualTo("2012 Genesis 1 1.1-1.25 In The Beginning.json"));
        }
    }

    public class MessageRepository
    {
    }
}
