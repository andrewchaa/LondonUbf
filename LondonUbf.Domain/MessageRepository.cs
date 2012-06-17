using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LondonUbf.Domain
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IMessageParser _parser;
        private readonly string _messageDirectory;
        private readonly DirectoryInfo _directory;

        public MessageRepository(IMessageParser parser, string messageDirectory)
        {
            _parser = parser;
            _messageDirectory = messageDirectory;
            _directory = new DirectoryInfo(_messageDirectory);
        }

        public IEnumerable<ServiceMessage> FindAll()
        {
            var files = _directory.GetFiles();

            IList<ServiceMessage> messages = new List<ServiceMessage>();
            foreach (var file in files)
            {
                var message = _parser.Parse(file.Name);
                message.FileName = file.Name;
                messages.Add(message);
            }

            return messages.OrderBy(m => m.LectureNo).OrderBy(m => m.Book);
        }

        public ServiceMessage Find(string fileName)
        {
            var message = _parser.Parse(fileName);
            message.Content = File.ReadAllText(Path.Combine(_messageDirectory, fileName));

            return message;
        }
    }
}