using KPMG.Infrastructure.Command;
using KPMG.Infrastructure.Engine;

namespace KPMG.Core.Command
{
    public class DefaultCommandBus : ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public DefaultCommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _commandHandlerFactory.GetHandler<TCommand>();
            if (handler != null)
                return handler.Execute(command);
            throw new CommandHandlerNotFoundException(typeof(TCommand));
        }
    }
}
