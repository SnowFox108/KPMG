using KPMG.Infrastructure.Data.Pagination;

namespace KPMG.Infrastructure.Data.Model
{
    public class TransactionDataSearchFilter
    {
        // Filter
        public PagingAndSortingModel Filter { get; set; }

        public TransactionDataSearchFilter()
        {
            Filter = new PagingAndSortingModel("Account");
        }
    }
}
