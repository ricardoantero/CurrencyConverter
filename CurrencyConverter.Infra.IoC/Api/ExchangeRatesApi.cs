using CurrencyConverter.Domain.ViewModels;
using CurrencyConverter.Infra.IoC.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace CurrencyConverter.Infra.IoC.Api
{
    public class ExchangeRatesApi : IExchangeRatesApi
    {
        async Task<List<TransactionsViewModel>> IExchangeRatesApi.ExchangeRates(int idUser, int idCurrencies, decimal OriginValue, string[] DestinationCurrency)
        {
            var listTransactions = new List<TransactionsViewModel>();
            var returnApi = RestAPI(DestinationCurrency);
            
            if(returnApi != null)
            {
                var returnJson = JsonConvert.DeserializeObject<dynamic>(returnApi);

                if (returnJson.rates != null)
                {
                    foreach (var itemRates in returnJson.rates)
                    {
                        listTransactions.Add(new TransactionsViewModel
                        {
                            UsersId = idUser,
                            CurrenciesId = idCurrencies
                        });
                    }
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
