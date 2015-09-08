using System.Reflection;
using Autofac;
using KPMG.Core.Command;
using KPMG.Core.CommandHandler;
using KPMG.Infrasructure.Adapter.IoC;
using KPMG.Infrasructure.Command;

namespace KPMG.WebAPI.Infrasructure.AutoFacRegister
{
    public class CommandRegister : BaseRegister, IDiRegister
    {
        public CommandRegister(ContainerBuilder builder) : base(builder)
        {
        }

        public void Register()
        {
            Builder.RegisterType<DefaultCommandBus>().As<ICommandBus>();
            Builder.RegisterType<TransactionDataCreateHandler>().As<ICommandHandler<TransactionDataCreateCommand>>();

            //var services = Assembly.Load("KPMG.Core");
            //Builder.RegisterAssemblyTypes(services)
            //.AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();

        }
    }
}
