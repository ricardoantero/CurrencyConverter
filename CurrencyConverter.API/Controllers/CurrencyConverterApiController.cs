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
    public class CurrencyConverterApiController : BaseAPIController<TransactionsViewModel>
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly ITransactionsService _transactionsService;
        private readonly IUsersService _usersService;
        private readonly IUsersRepository _usersRepository;
        private readonly ICurrenciesService _currenciesService;
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly IExchangeRatesApi _iexchangeratesapi;
        private readonly ILogger _logger;
        public CurrencyConverterApiController(ITransactionsRepository transactionsRepository,
                                              ITransactionsService transactionsService,
                                              IUsersRepository usersRepository,
                                              IUsersService usersService,
                                              ICurrenciesRepository currenciesRepository,
                                              ICurrenciesService currenciesService,
                                              IExchangeRatesApi iexchangeratesapi,
                                              ILogger logger) : base(transactionsService, logger)
        {

            _transactionsRepository = transactionsRepository;
            _transactionsService = transactionsService;
            _usersRepository = usersRepository;
            _usersService = usersService;
            _currenciesRepository = currenciesRepository;
            _currenciesService = currenciesService;
            _iexchangeratesapi = iexchangeratesapi;
            _logger = logger;
        }

        [Route("currencytransaction")]
        [HttpPost]
        public async Task<ActionResult<TransactionsViewModel>> CurrencyTransaction(int idUser,
                                                                                string OriginCurrency,
                                                                                decimal OriginValue,
                                                                                string[] DestinationCurrency)
        {
            try
            {
                var userViewModel = await _usersRepository.GetByIdAsync(idUser);
                var currenciesViewsModel = await _currenciesRepository.GetAll(x => x.CurrencyCode == OriginCurrency);

                if (userViewModel == null)
                {
                    Logger.Information("log {param1}", new { Return = $"Method ConvertCurrency", Error = "User not found" });
                    return NotFound(userViewModel);
                }

                if (!currenciesViewsModel.Any())
                {
                    Logger.Information("log {param1}", new { Return = $"Method ConvertCurrency", Error = "Currency not found" });
                    return NotFound(currenciesViewsModel);
                }

                List<TransactionsViewModel> transactionsViewModel = await _iexchangeratesapi.ExchangeRates(idUser, currenciesViewsModel.FirstOrDefault().Id, OriginValue, DestinationCurrency);

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Information("log {param1}", new { Return = $"Method ConvertCurrency", Error = ex.Message });
                return Problem();
            }
        }
    }
}
