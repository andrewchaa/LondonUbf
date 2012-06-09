using LondonUbf.Domain;
using NUnit.Framework;

namespace LondonUbf.Test.Unit
{
    [TestFixture]
    public class FileContentParsingTest
    {
        private IMessageParser   _parser;

        [SetUp]
        public void BeforeEachTest()
        {
            _parser = new FileContentParser();
        }

        [Test]
        public void Should_Parse_The_Content()
        {
            const string messageFileContent =
                @"2011 Luke 20                                              					      22 May 2011

YOUR KINGDOM COME

Luke 11:1-13
Key verse 11:2
‘He said to them, When you pray, say: 'Father, hallowed be your name, your kingdom come.'’


Prayer is communication with God. In this passage Jesus teaches us how to communicate with God. In particular he teaches us two things; what to include in our prayers and the correct attitude in prayer. God wants a father / child relationship with us and that he wants us to pray boldly for his glory, that his kingdom would come and for our needs. And when we bring all of these things together we learn that our prayer lives should be dynamic, powerful and refreshing. We should have prayer lives which reflect what God wants and have confidence that he will answer. I pray that through today’s message we refresh our prayer lives and build a deeper relationship with our father God.
";

            var message = _parser.Parse(messageFileContent);

            Assert.That(message.Year, Is.EqualTo(2011));
            Assert.That(message.Book, Is.EqualTo("Luke"));
            Assert.That(message.LectureNo, Is.EqualTo(20));
            Assert.That(message.Title, Is.EqualTo("Your Kingdom Come"));
            Assert.That(message.Chapter, Is.EqualTo("11:1-13"));
        }

        [Test]
        public void Shoud_Fail_Gracefully_And_Return_Empty_Message()
        {
            const string failingContent =
                @"Luke 20                                                                                              

YOUR KINGDOM COME

Luke 11:1-13
Key verse 11:2
‘He said to them, When you pray, say: 'Father, hallowed be your name, your kingdom come.'’


Prayer is communication with God. In this passage Jesus teaches us how to communicate with God. In particular he teaches us two things; what to include in our prayers and the correct attitude in prayer. God wants a father / child relationship with us and that he wants us to pray boldly for his glory, that his kingdom would come and for our needs. And when we bring all of these things together we learn that our prayer lives should be dynamic, powerful and refreshing. We should have prayer lives which reflect what God wants and have confidence that he will answer. I pray that through today’s message we refresh our prayer lives and build a deeper relationship with our father God.
";
            var message = _parser.Parse(failingContent);

            Assert.That(message.Year, Is.EqualTo(0));
            Assert.That(message.Book, Is.Null);

        }
    }
}
