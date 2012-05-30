using LondonUbfWeb.Domain.Models;
using NUnit.Framework;

namespace LondonUbfWeb.Test.TestCases
{
    [TestFixture]
    public class TestLectureViewModel
    {
        [Test]
        public void SeoTitle_Should_Replace_Space_With_Dash()
        {
            //arrange
            //act
            var viewModel = new LectureViewModel { Title = "I am a king" };

            //assert
            Assert.That(viewModel.SeoTitle, Is.EqualTo("I-am-a-king"));
        }

        [Test]
        public void SeoTitle_Should_Remove_Non_Alpha_Numeric_Characters()
        {
            //arrange
            //act
            var viewModel = new LectureViewModel {Title = "What is your name?"};

            //assert
            Assert.That(viewModel.SeoTitle, Is.EqualTo("What-is-your-name"));
        }
    }
}
