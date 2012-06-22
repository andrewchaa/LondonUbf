using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LondonUbf.Domain;
using LondonUbf.Domain.Repositories;
using LondonUbf.Infrastructure;

namespace LondonUbf.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<FileNameParser, IMessageParser>());
            container.Register(Component.For<ExceptionLogger>());
            container.Register(Component.For<MessageRepositoryInterceptor>());
            container.Register(
                Component.For<MessageRepository, IMessageRepository>()
                .DependsOn(new { messageDirectory = HostingEnvironment.MapPath("/content/messages")})
                .Interceptors<MessageRepositoryInterceptor>()
                );
        }
    }
}