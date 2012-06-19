using System.Collections.Generic;

namespace LondonUbf.Domain.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<ServiceMessage> FindAll();
        ServiceMessage Find(string fileName);
    }
}