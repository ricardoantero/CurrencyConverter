using CurrencyConverter.Domain.ViewModels;
using CurrencyConverter.Infra.IoC.Api.Interface;
using System.Text.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using System.Globalization;
using static CurrencyConverter.Domain.ViewModels.TransactionsViewModel;

namespace CurrencyConverter.Infra.IoC.Api
{
    public class ExchangeRatesApi : IExchangeRatesApi
    {
        async Task<List<TransactionsViewModel>> IExchangeRatesApi.ExchangeRates(int idUser, int idCurrencies, string OriginCurrencies, decimal OriginValue, string[] DestinationCurrency)
        {
            var listTransactions = new List<TransactionsViewModel>();
            var returnApi = RestAPI(DestinationCurrency);

            if (returnApi != null)
            {
                var returnJson = JsonConvert.DeserializeObject<TransactionsDeserializeViewModel>(returnApi) ;

                if (returnJson.rates != null)
                {
                    foreach (var itemRates in returnJson.rates)
                    {
                        decimal conversionRate = Convert.ToDecimal(itemRates.Value.Replace(".", ","));
                        decimal destinationValue = (conversionRate * OriginValue);
                        var conversionDate = Convert.ToDateTime(returnJson.date);

                        listTransactions.Add(new TransactionsViewModel
                        {
                            UsersId = idUser,
                            CurrenciesId = idCurrencies,
                            OriginCurrency = returnJson.@base,
                            OriginValue = OriginValue,
                            DestinationCurrency = itemRates.Key,
                            DestinationValue = destinationValue,
                            ConversionRate = conversionRate,
                            ConversionDate = conversionDate
                        });
                    }
                }
                if (returnJson.error != null)
                {
                    var transactions = new TransactionsViewModel
                    {
                        Error = new TransactionsErrorViewModel
                        {
                            code = returnJson.error.code,
                            message = returnJson.error.message
                        }
                    };

                    listTransactions.Add(transactions);
                }
            }
            return listTransactions;
        }

        public string RestAPI(string[] DestinationCurrency)
        {
            var DestinationsCurrencies = String.Join(",", DestinationCurrency);

            var client = new RestClient($"http://api.exchangeratesapi.io/v1/latest?access_key=0ce869d9bebdb1a32bfc3299fe1c5a51&symbols={DestinationsCurrencies}&format=1");
            var request = new RestRequest(Method.GET);

            request.AddHeader("cache-control", "no-cache");

            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
