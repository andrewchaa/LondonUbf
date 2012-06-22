﻿using System;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using LondonUbf.Domain;
using LondonUbf.Domain.Repositories;
using NUnit.Framework;

namespace LondonUbf.Test.Integration
{
    [TestFixture]
    public class MessageRepositoryTest
    {
        private MessageRepository _repository;
        const string _messagePath = @"..\..\Messages";


        [SetUp]
        public void BeforeEachTest()
        {
            _repository = new MessageRepository(new FileNameParser(), _messagePath);
        }

        [Test]
        public void Should_List_Files_In_The_Message_Directory()
        {
            
            var messages = _repository.FindAll();

            Assert.That(messages.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void Should_Fine_A_Message_By_File_Name_As_Id()
        {
            var message = _repository.Find("2012 Genesis 1 1.1-1.25 In The Beginning");

            Assert.That(message.Chapter, Is.EqualTo("1:1-1:25"));
            Assert.That(message.Content.Length, Is.GreaterThan(0));
        }

    }
}
