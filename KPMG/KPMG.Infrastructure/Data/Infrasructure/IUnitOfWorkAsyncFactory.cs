
namespace KPMG.Infrastructure.Data.Infrasructure
{
    public interface IUnitOfWorkAsyncFactory
    {
        IUnitOfWork Create();
    }
}
