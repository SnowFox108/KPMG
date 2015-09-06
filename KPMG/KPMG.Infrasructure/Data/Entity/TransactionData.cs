using System.ComponentModel.DataAnnotations;
using KPMG.Infrasructure.Data.Infrasructure;

namespace KPMG.Infrasructure.Data.Entity
{
    public class TransactionData : TrackableEntity
    {
        [Required]
        public string Account { get; set; }
        public string Description { get; set; }
        [StringLength(3)]
        [Required]
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}
