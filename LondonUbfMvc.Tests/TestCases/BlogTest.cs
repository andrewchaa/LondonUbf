using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LondonUbfMvc.Models.Entity;

namespace LondonUbfMvc.Tests.TestCases
{
    [TestClass]
    public class BlogTest
    {
        [TestMethod]
        public void Post_Properties_ValueReturn()
        {
            Post post = new Post();
            post.Title = "Keller on the Gospel";
            post.Date = new DateTime(2010, 05, 28);
            post.Author = "Ruthie";
            post.Content = "Sample content";

            Assert.AreEqual("Keller on the Gospel", post.Title);
            Assert.AreEqual(new DateTime(2010, 05, 28), post.Date);
            Assert.AreEqual("Ruthie", post.Author);
            Assert.AreEqual("Sample content", post.Content);
        }
    }
}
