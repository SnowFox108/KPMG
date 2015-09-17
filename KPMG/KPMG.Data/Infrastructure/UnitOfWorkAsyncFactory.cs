using KPMG.Infrastructure.Data.Infrasructure;

namespace KPMG.Data.Infrastructure
{
    public class UnitOfWorkAsyncFactory : IUnitOfWorkAsyncFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new ContentContext());
        }
    }
}
