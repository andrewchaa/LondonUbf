using System.Linq;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Domain.Repositories;
using NUnit.Framework;

namespace LondonUbfWeb.Test.TestCases
{
    [TestFixture]
    public class RecentMessageTest
    {
        MessageRepository _repos;
        string path;

        [SetUp]
        public void Setup()
        {
            path = @"C:\Users\Andrew\My Projects\LondonUbfMvc\LondonUbfMvc\Message";
            _repos = new MessageRepository(path, string.Empty);
        }

        [Test]
        public void RepositoryFile_Returns_ServerFile_Object()
        {
            Assert.AreEqual(typeof(ServerFile), _repos.ListItems().FirstOrDefault().GetType());
        }

        [Test]
        public void Repository_Return_Files_With_Properties_Not_Null()
        {
            ServerFile file = _repos.ListItems().FirstOrDefault();
            Assert.IsNotNullOrEmpty(file.Name);
        }

        [Test]
        public void Repositoryo_GetFiles_Seach_Subdirectories()
        {
            var files = _repos.ListItems();
            Assert.IsTrue(files.Any(f => f.Name.Contains("fileInSubfolder.pdf")));
            Assert.IsTrue(files.Any(f => f.Name.Contains("subflder2text.txt")));
        }

        [Test]
        public void Repository_GetFiles_Return_Result_With_Search_Condition()
        {
            _repos = new MessageRepository(path, "Tim");
            var files = _repos.ListItems();

            Assert.AreEqual(1, files.Count());
        }

        [Test]
        public void Repository_GetFiles_Search_Ignore_Case()
        {
            _repos = new MessageRepository(path, "tim");
            var files = _repos.ListItems();

            Assert.AreEqual(1, files.Count());
        }
    }
}
