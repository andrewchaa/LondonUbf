using System.Collections.Generic;

namespace LondonUbf.Domain
{
    public interface IMessageRepository
    {
        IEnumerable<ServiceMessage> FindAll();
        ServiceMessage Find(string fileName);
    }
}