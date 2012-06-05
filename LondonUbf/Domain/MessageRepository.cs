using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LondonUbf.Domain
{
    public class MessageRepository
    {
        private readonly string _messageDirectory;
        private DirectoryInfo _directory;

        public MessageRepository(string messageDirectory)
        {
            _messageDirectory = messageDirectory;
            _directory = new DirectoryInfo(_messageDirectory);
        }

        public IEnumerable<ServiceMessage> FindAll()
        {
            var files = _directory.GetFiles();

            IList<ServiceMessage> messages = new List<ServiceMessage>();
            foreach (var file in files)
            {
                var message = ServiceMessage.From(file.Name);
                message.FileName = file.Name;
                messages.Add(message);
            }

            return messages;
        }

        public ServiceMessage Find(string fileName)
        {
            var message = ServiceMessage.From(fileName);
            message.Content = File.ReadAllText(Path.Combine(_messageDirectory, fileName));

            return message;
        }
    }
}