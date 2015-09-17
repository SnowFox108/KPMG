using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using KPMG.Infrastructure.Adapter.IoC;
using WebGrease.Configuration;

namespace KPMG.WebAPI.Infrastructure
{
    public class AutofacFacotry : IDiContainerFactory
    {
        public IDiContainer Create()
        {
            var builder = new ContainerBuilder();

            var registers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IDiRegister).IsAssignableFrom(t) && t.IsClass);

            foreach (var item in registers)
            {
                var register = Activator.CreateInstance(item, builder) as IDiRegister;
                if (register != null)
                    register.Register();
            }

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);

            return new AutofacContainer(container);
        }
    }
}
