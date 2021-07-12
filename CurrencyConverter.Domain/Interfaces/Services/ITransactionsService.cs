using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Interfaces.Services
{
    public interface ITransactionsService : IBaseService<TransactionsViewModel>
    {
        Task<IEnumerable<TransactionsViewModel>> FindUserTransactions(int id);
    }
}
