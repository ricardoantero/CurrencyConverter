using CurrencyConverter.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infra.IoC.Api.Interface
{
    public interface IExchangeRatesApi
    {
        Task<List<TransactionsViewModel>> ExchangeRates(int idUser,
                                        int OriginCurrency,
                                        string OriginCurrencies,
                                        decimal OriginValue,
                                        string[] DestinationCurrency);
    }
}
