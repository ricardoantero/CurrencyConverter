using AutoMapper;
using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Domain.ViewModels;
using CurrencyConverter.Infra.IoC.Api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Controllers
{
    [Route("api/currencyconverter")]
    [ApiController]
    public class CurrencyConverterApiController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IUsersService _usersService;
        private readonly ICurrenciesService _currenciesService;
        private readonly IExchangeRatesApi _iexchangeratesapi;
        private readonly ILogger _logger;
        public CurrencyConverterApiController(
                                              ITransactionsService transactionsService,
                                              IUsersService usersService,
                                              ICurrenciesService currenciesService,
                                              IExchangeRatesApi iexchangeratesapi,
                                              ILogger logger)
        {


            _transactionsService = transactionsService;
            _usersService = usersService;
            _currenciesService = currenciesService;
            _iexchangeratesapi = iexchangeratesapi;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<TransactionsViewModel>> CurrencyTransaction(int idUser,
                                                                                string OriginCurrency,
                                                                                decimal OriginValue,
                                                                                string[] DestinationCurrency)
        {
            try
            {
                var listTransactionsDisplay = new List<TransactionsViewModel>();

                var usersViewModel = await _usersService.GetById(idUser);
                var currenciesViewsModel = await _currenciesService.FindCurrencies(OriginCurrency);

                if (usersViewModel == null)
                {
                    _logger.Information("log {param1}", new { Return = $"Method ConvertCurrency", Error = "User not found" });
                    return Notification(null, "User not found", false);
                }

                if (!currenciesViewsModel.Any())
                {
                    _logger.Information("log {param1}", new { Return = $"Method ConvertCurrency", Error = "Currency not found" });
                    return Notification(null, "Currency not found", false);
                }

                List<TransactionsViewModel> listTransactions = await _iexchangeratesapi.ExchangeRates(idUser, currenciesViewsModel.FirstOrDefault().Id, OriginCurrency, OriginValue, DestinationCurrency);

                if (!listTransactions.Any(x => x.Error != null))
                {
                    foreach (var item in listTransactions)
                    {
                         var ret = await _transactionsService.Add(item);

                        listTransactionsDisplay.Add(ret.FirstOrDefault());
                    }
                }
                else
                {
                    var error = listTransactions.FirstOrDefault().Error;
                    return Notification(error.code, error.message, false);  
                }

                return Ok(listTransactionsDisplay);
            }
            catch (Exception ex)
            {
                _logger.Information("log {param1}", new { Return = $"Method ConvertCurrency", Error = ex.Message });
                return Problem();
            }
        }
        protected OkObjectResult Notification(string code, string message, bool sucesss = true) => Ok(new
        {
            success = sucesss,
            data = new TransactionsErrorViewModel { code = code, message = message }
        });
    }
}
