using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.ViewModels
{
    public class CurrenciesViewModel: BaseViewModel
    {
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
    }
}
