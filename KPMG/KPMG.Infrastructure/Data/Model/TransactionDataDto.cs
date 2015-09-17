using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace KPMG.Infrastructure.Data.Model
{
    [DataContract]
    public class TransactionDataDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter a Account.")]
        [DataMember]
        public string Account { get; set; }

        [DataMember]
        public string Description { get; set; }

        [StringLength(3, ErrorMessage = "Maximum characters is 3")]
        [Required(ErrorMessage = "Please enter a Currency Code")]
        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public decimal Amount { get; set; }
    }
}
