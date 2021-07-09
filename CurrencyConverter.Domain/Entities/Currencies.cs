using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.Entities
{
    public class Currencies : BaseEntity
    {
        public string Currency { get; set; }

        public string Currencycode { get; set; }

    }
}
