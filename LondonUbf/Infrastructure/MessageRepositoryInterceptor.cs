using System;
using Castle.DynamicProxy;
using LondonUbf.Domain;

namespace LondonUbf.Infrastructure
{
    public class MessageRepositoryInterceptor : IInterceptor
    {
        private readonly ExceptionLogger _logger;

        public MessageRepositoryInterceptor(ExceptionLogger logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                string messageName = invocation.Arguments.Length > 0 ? invocation.Arguments[0].ToString() : string.Empty;

                _logger.Log(string.Format("{0}.{1},  Message: {2} ", invocation.TargetType.Name, invocation.Method.Name, messageName));
                invocation.Proceed();
            }
            catch(Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
    }
}