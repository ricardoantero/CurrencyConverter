using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.ViewModels
{
    public class TransactionsViewModel : BaseViewModel
    {
        public int UsersId { get; set; }
        public int CurrenciesId { get; set; }
        public string OriginCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public decimal OriginValue { get; set; }
        public decimal DestinationValue { get; set; }

        public UsersViewModel Users { get; set; }
        public CurrenciesViewModel Currencies { get; set; }
    }
}
