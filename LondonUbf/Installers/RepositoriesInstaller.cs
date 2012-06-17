using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LondonUbf.Domain;

namespace LondonUbf.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<FileNameParser, IMessageParser>());
            container.Register(
                Component.For<MessageRepository, IMessageRepository>()
                .DependsOn(new { messageDirectory = HostingEnvironment.MapPath("/Content/messages")})
                );
        }
    }
}