using LondonUbfWeb.Controllers;
using MvcContrib.TestHelper;
using Norm;
using NUnit.Framework;
using System.Web.Routing;

namespace LondonUbfWeb.Test.TestCases
{
    [TestFixture]
    public class TestRoutes
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            RouteTable.Routes.Clear();
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void Root_Matches_Contents_Controller_Index_Action()
        {
            "~/".ShouldMapTo<ContentsController>(x => x.Index());
        }

        [Test]
        public void RecentMessages_Should_Map_To_File_RecentMessage()
        {
            "~/file/recentmessage".ShouldMapTo<FileController>(x => x.RecentMessage(null, null));
        }

        [Test]
        public void Lecture_View_LInk_Should_Have_Book_And_Title()
        {
            "~/lecture/view/john/i-am-a-king/5e935904767f7b540b000000".ShouldMapTo<LectureController>(c => c.View(new ObjectId("5e935904767f7b540b000000")));
        }

        [Test]
        public void Lecture_Mark_Should_Map_To_Index_With_BookName()
        {
            "~/lecture/index/mark/0".ShouldMapTo<LectureController>(c => c.Index("mark", 0));
        }
    }
}
