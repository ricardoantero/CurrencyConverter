using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infra.Data.Repositories
{
    public class CurrenciesRepository : BaseRepository<Currencies>, ICurrenciesRepository
    {
        public CurrenciesRepository(SqlDbContext context) : base(context) { }

        public async Task<IEnumerable<Currencies>> FindCurrencies(string CurrencyCode)
        {
            return await Entities.Where(p => p.CurrencyCode == CurrencyCode).ToListAsync();
        }
    }
}
