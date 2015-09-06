using System;

namespace KPMG.Infrasructure.Data.Pagination
{
    public class PaginationModel
    {
        public int TotalItems { get; set; }

        public int TotalPages
        {
            get { return ItemsPerPage == 0 ? 0 : (int) Math.Ceiling((float) TotalItems/ItemsPerPage); }
        }

        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
    }
}
