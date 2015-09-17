using System.Collections.Generic;
using System.Linq;
using KPMG.Infrastructure.Data.Entity;
using KPMG.Infrastructure.Data.Infrasructure;
using KPMG.Infrastructure.Data.Model;
using KPMG.Infrastructure.Helper;

namespace KPMG.Core.Services
{
    public class TransactionDataService : BaseService, ITransactionDataService
    {
        public TransactionDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<TransactionData> GetTransactionData(TransactionDataSearchFilter searchFilter)
        {
            var results =
                UnitOfWork.Repository<TransactionData>()
                    .Get(
                        orderBy:
                            t =>
                                t.OrderBy(searchFilter.Filter.Sorting.SortOrder,
                                    searchFilter.Filter.Sorting.SortDirection),
                        pageNumber: searchFilter.Filter.Paging.CurrentPage,
                        pageSize: searchFilter.Filter.Paging.ItemsPerPage);
            return results;
        }

        public int GetTransactionDataCount(TransactionDataSearchFilter searchFilter)
        {
            return UnitOfWork.Repository<TransactionData>()
                .Get(
                    orderBy:
                        t =>
                            t.OrderBy(searchFilter.Filter.Sorting.SortOrder,
                                searchFilter.Filter.Sorting.SortDirection)).Count();
        }
    }
}
