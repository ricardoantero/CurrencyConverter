using CurrencyConverter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Interfaces
{
    public interface ITransactionsRepository : IBaseRepository<Transactions>
    {
        Task<IEnumerable<Transactions>> FindUserTransactions(int id);
    }
}
