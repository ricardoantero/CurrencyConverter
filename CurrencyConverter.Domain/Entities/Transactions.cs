using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.Entities
{
    public class Transactions : BaseEntity
    {
        public int UsersId { get; set; }
        public int CurrenciesId { get; set; }
        public string OriginCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public decimal OriginValue { get; set; }
        public decimal DestinationValue { get; set; }
        public decimal ConversionRate { get; set; }
        public DateTime ConversionDate { get; set; }

        public Users Users { get; set; }
        public Currencies Currencies { get; set; }
    }
}
