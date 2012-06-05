using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LondonUbf.Domain
{
    public class MessageRepository
    {
        private readonly string _messageDirectory;

        public MessageRepository(string messageDirectory)
        {
            _messageDirectory = messageDirectory;
        }

        public IEnumerable<ServiceMessage> FindAll()
        {
            var directory = new DirectoryInfo(_messageDirectory);
            var files = directory.GetFiles();

            IList<ServiceMessage> messages = new List<ServiceMessage>();
            foreach (var file in files)
            {
                var message = ServiceMessage.From(file.Name);
                message.FileName = file.FullName;
                messages.Add(message);
            }

            return messages;
        }
    }
}