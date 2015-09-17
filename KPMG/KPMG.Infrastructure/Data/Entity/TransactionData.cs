using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KPMG.Infrastructure.Data.Infrasructure;

namespace KPMG.Infrastructure.Data.Entity
{
    [Table("TransactionData")]
    public class TransactionData : TrackableEntity
    {
        [Required]
        public string Account { get; set; }
        [Required]
        public string Description { get; set; }
        [StringLength(3)]
        [Required]
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}
