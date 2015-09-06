
namespace KPMG.Infrasructure.Adapter.IoC
{
    public interface IDiContainer
    {
        TService GetInstance<TService>() where TService : class;
    }
}
