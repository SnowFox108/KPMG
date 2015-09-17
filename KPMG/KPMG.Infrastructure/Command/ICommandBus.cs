
namespace KPMG.Infrastructure.Command
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
