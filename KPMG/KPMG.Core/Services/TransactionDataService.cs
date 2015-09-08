using System.Collections.Generic;
using KPMG.Infrasructure.Data.Entity;
using KPMG.Infrasructure.Data.Infrasructure;
using KPMG.Infrasructure.Data.Model;
using KPMG.Infrasructure.Helper;

namespace KPMG.Core.Services
{
    public class TransactionDataService : BaseService, ITransactionDataService
    {
        public TransactionDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<TransactionData> GetTransactionData(TransactionDataSearchFilter searchFilter)
        {
            return
                UnitOfWork.Repository<TransactionData>()
                    .Get(
                        orderBy:
                            t =>
                                t.OrderBy(searchFilter.Filter.Sorting.SortOrder,
                                    searchFilter.Filter.Sorting.SortDirection),
                        pageNumber: searchFilter.Filter.Paging.CurrentPage,
                        pageSize: searchFilter.Filter.Paging.ItemsPerPage);
        }
    }
}
