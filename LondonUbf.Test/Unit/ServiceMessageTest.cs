using System.IO;
using LondonUbf.Domain;
using NUnit.Framework;
using ServiceStack.Text;

namespace LondonUbf.Test.Unit
{
    [TestFixture]
    public class ServiceMessageTest
    {
        [Test]
        public void Should_Populate_Properties_From_File_Name()
        {
            const string fileName = "2012 Genesis 1 1.1-1.25 In The Beginning.js";

            var message = ServiceMessage.From(fileName);

            Assert.That(message.Year, Is.EqualTo(2012));
            Assert.That(message.Book, Is.EqualTo("Genesis"));
            Assert.That(message.LectureNo, Is.EqualTo(1));
            Assert.That(message.Chapter, Is.EqualTo("1:1-1:25"));
            Assert.That(message.Title, Is.EqualTo("In The Beginning"));
            Assert.That(message.FileName, Is.EqualTo(fileName));
        }


        [Test, Ignore]
        public void Should_Save_To_A_File()
        {
            var message = new ServiceMessage
                              {
                                  Content = "The first words of the bible are",
                                  Book = "Genesis",
                                  Chapter = "Ch 1:1-25",
                                  LectureNo = 1,
                                  Year = 2012,
                                  Title = "IN THE BEGINNING \"God\""
                              };

            string text = JsonSerializer.SerializeToString(message);
            File.WriteAllText(@"c:\temp\test.json", text);

            Assert.That(text, Is.EqualTo(""));

        }

        [Test]
        public void Chapter_Replace_Dot_To_Colon_To_Follow_The_Convention()
        {
            var message = ServiceMessage.From("2012 Genesis 1 1.1-1.25 In The Beginning.js");

            Assert.That(message.Chapter, Is.EqualTo("1:1-1:25"));
        }

        [Test]
        public void Content_Newline_Gets_Converted_To_Html_Br()
        {
            var message = new ServiceMessage();
            message.Content = "Test\r\n";

            Assert.That(message.ContentHtml, Is.EqualTo("Test<br />"));
        }


    }
}
