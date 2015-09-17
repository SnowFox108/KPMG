using Autofac;
using KPMG.Core.Command;
using KPMG.Core.CommandHandler;
using KPMG.Infrastructure.Adapter.IoC;
using KPMG.Infrastructure.Command;

namespace KPMG.WebAPI.Infrastructure.AutoFacRegister
{
    public class CommandRegister : BaseRegister, IDiRegister
    {
        public CommandRegister(ContainerBuilder builder) : base(builder)
        {
        }

        public void Register()
        {            
            Builder.RegisterType<DefaultCommandBus>().As<ICommandBus>().InstancePerLifetimeScope();
            Builder.RegisterType<DefaultCommandHandlerFactory>().As<ICommandHandlerFactory>().InstancePerLifetimeScope();
        }
    }
}
