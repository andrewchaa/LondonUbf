using LondonUbfWeb.Domain.Models;
using NUnit.Framework;

namespace LondonUbfWeb.Test.TestCases
{
    [TestFixture]
    public class TestLectureInput
    {
        [Test]
        public void ContentNoHtml_Should_Strip_Off_Html_Tags()
        {
            //arrange
            //act
            var input = new LectureInput { Content = "Hello <b>Andy<b>!<br />Nice to see you." };

            //assert
            Assert.That(input.ContentNoHtml, Is.EqualTo("Hello Andy!Nice to see you."));
        }
    }
}
