using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LondonUbf.Domain;
using LondonUbf.Domain.Repositories;
using Moq;
using NUnit.Framework;

namespace LondonUbf.Test.Unit
{
    [TestFixture]
    public class MessageRepositoryTest
    {
        [Ignore]
        public void Log_Should_Be_Called_Given_Find_Method_Call()
        {
            var logger = new Mock<ExceptionLogger>();

            var repository = new MessageRepository(new FileNameParser(), string.Empty);
            repository.Find("Test");

            logger.Verify(l => l.Log(It.IsAny<Exception>()));

        }
    }
}
