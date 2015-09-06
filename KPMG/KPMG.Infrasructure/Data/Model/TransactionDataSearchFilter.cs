using KPMG.Infrasructure.Data.Pagination;

namespace KPMG.Infrasructure.Data.Model
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
