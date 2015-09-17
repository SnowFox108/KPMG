using System;
using System.Linq;
using System.Reflection;
using KPMG.Infrastructure.Command;
using KPMG.Infrastructure.Data.Infrasructure;

namespace KPMG.Core.CommandHandler
{
    public class DefaultCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public DefaultCommandHandlerFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICommandHandler<T> GetHandler<T>() where T : ICommand
        {
            var handler = Assembly.Load("KPMG.Core").GetTypes().FirstOrDefault(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>) 
                          && i.GetGenericArguments().Any(arg => arg == typeof(T))));

            if (handler != null)
                return Activator.CreateInstance(handler, _unitOfWork) as ICommandHandler<T>;

            throw new CommandHandlerNotFoundException(typeof(T));
        }
    }
}
