using KPMG.Infrastructure.Data.Infrasructure;

namespace KPMG.Core.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

    }
}
