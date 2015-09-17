
namespace KPMG.Infrastructure.Adapter.IoC
{
    public interface IDiContainer
    {
        TService GetInstance<TService>() where TService : class;
    }
}
