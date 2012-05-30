using System.Linq;
using LondonUbfWeb.Domain.Interfaces;
using LondonUbfWeb.Domain.Repositories;
using NUnit.Framework;

namespace LondonUbfWeb.Test.TestCases
{
    [TestFixture]
    public class FileTest
    {
        string _fileDir = @"C:\Users\Andrew\My Projects\LondonUbfMvc\LondonUbfMvc\Message";
        IRepositoryFile repo;

        [SetUp]
        public void SetupFileTest()
        {
            repo = new FileRepository(_fileDir, string.Empty, string.Empty);
        }

        [Test]
        public void List_Items()
        {
            Assert.IsTrue(repo.ListItems().Count() > 0);
        }

        [Test]
        public void List_Directories()
        {
            var items = repo.ListItems();
            Assert.IsTrue(items.Any(d => d.IsFolder));
        }

        [Test]
        public void List_Files()
        {
            Assert.IsTrue(repo.ListItems().Any(f => f.Name.Contains("2 Ti lec 2-4 que.doc")));
        }

        [Test]
        public void List_Items_In_A_Specific_Folder()
        {
            repo = new FileRepository(_fileDir, @"\subfolder", string.Empty);
            var items = repo.ListItems();
            Assert.IsTrue(items.Any(d => d.Name == "subfolder2"));

        }

        [Test]
        public void Fullname_returns_only_part_of_a_path()
        {
            var items = repo.ListItems();
            Assert.IsFalse(items.Any(f => f.PartialPath.Contains(_fileDir)));
        }

        [Test]
        public void Get_Parent_Directory_Of_A_Folder()
        {
            var item = repo.GetItem();
            Assert.AreEqual(string.Empty, item.ParentDirectory);

            repo = new FileRepository(_fileDir, @"\subfolder", string.Empty);
            var item2 = repo.GetItem();
            Assert.AreEqual("\\", item2.ParentDirectory);
        }

    }
}
