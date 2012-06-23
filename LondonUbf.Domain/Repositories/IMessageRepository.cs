using System.Collections.Generic;

namespace LondonUbf.Domain.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<ServiceMessage> FindAllMessages();
        ServiceMessage Find(string fileName);
        IEnumerable<Book> FindAllBooks();
        IEnumerable<ServiceMessage> FindMessagesBy(string book);
    }
}