using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.ViewModels
{
    public class CurrenciesViewModel: BaseViewModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual bool Active { get; set; }
    }
}
