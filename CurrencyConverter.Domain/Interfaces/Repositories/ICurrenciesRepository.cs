using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Interfaces
{
    public interface ICurrenciesRepository : IBaseRepository<Currencies>
    {
        Task<IEnumerable<Currencies>> FindCurrencies(string CurrencyCode);
    }
}
