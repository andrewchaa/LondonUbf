namespace LondonUbf.Domain
{
    public interface IMessageParser
    {
        ServiceMessage Parse(string input);
    }
}