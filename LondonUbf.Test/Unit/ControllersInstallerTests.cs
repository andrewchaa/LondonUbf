using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.Windsor;
using LondonUbf.Installers;
using NUnit.Framework;
using LondonUbf.Controllers;

namespace LondonUbf.Test.Unit
{
    [TestFixture]
    public class ControllersInstallerTests
    {
        private IWindsorContainer _containerWithControllers;

        public ControllersInstallerTests()
        {
            
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _containerWithControllers = new WindsorContainer().Install(new ControllersInstaller());
        }

        [Test]
        public void All_Controllers_Implement_IController()
        {
            var allHandlers = GetAllHandlers(_containerWithControllers);
            var controllerHandlers = GetHandlersFor(typeof (IController), _containerWithControllers);

            Assert.That(allHandlers, Is.Not.Empty);
            Assert.That(allHandlers, Is.EqualTo(controllerHandlers));
        }

        [Test]
        public void All_Controllers_Are_Registered()
        {
            var allControllers = GetPublicClassesFromAssembly(c => c.Is<IController>());
            var registeredControllers = GetImplementaionTypesFor(typeof (IController), _containerWithControllers);

            Assert.That(allControllers, Is.EqualTo(registeredControllers));
        }

        [Test]
        public void All_And_Only_Controllers_Have_Controllers_Suffix()
        {
            var allControllers = GetPublicClassesFromAssembly(c => c.Name.EndsWith("Controller"));
            var registeredControllers = GetImplementaionTypesFor(typeof (IController), _containerWithControllers);

            Assert.That(allControllers, Is.EqualTo(registeredControllers));
        }

        [Test]
        public void All_Controllers_Are_Trasient()
        {
            var nonTransientControllers = GetHandlersFor(typeof (IController), _containerWithControllers)
                .Where(c => c.ComponentModel.LifestyleType != LifestyleType.Transient);

            Assert.That(nonTransientControllers, Is.Empty);
        }

        private Type[] GetImplementaionTypesFor(Type type, IWindsorContainer container)
        {
            return GetHandlersFor(type, container)
                .Select(h => h.ComponentModel.Implementation)
                .OrderBy(t => t.Name)
                .ToArray();
        }

        private Type[] GetPublicClassesFromAssembly(Predicate<Type> where)
        {
            return typeof (HomeController).Assembly.GetExportedTypes()
                .Where(t => t.IsClass)
                .Where(t => t.IsAbstract == false)
                .Where(where.Invoke)
                .OrderBy(t => t.Name)
                .ToArray();
        }


        private IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof (object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }
    }
}
