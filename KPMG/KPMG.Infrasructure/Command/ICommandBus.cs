
namespace KPMG.Infrasructure.Command
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
