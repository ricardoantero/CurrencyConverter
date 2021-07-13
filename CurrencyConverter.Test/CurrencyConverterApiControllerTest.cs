using CurrencyConverter.API.Controllers;
using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Infra.IoC.Api.Interface;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Test
{
    public class CurrencyConverterApiControllerTest
    {
        readonly ITransactionsService _transactionsService;
        readonly IUsersService _usersService;
        readonly ICurrenciesService _currenciesService;
        readonly IExchangeRatesApi _iexchangeratesapi;
        readonly Serilog.ILogger _logger;

        CurrencyConverterApiController _controller;
        public CurrencyConverterApiControllerTest()
        {
            _controller = new CurrencyConverterApiController(_transactionsService,
                                                             _usersService,
                                                             _currenciesService,
                                                             _iexchangeratesapi,
                                                             _logger); 
        }
        [Theory]
        [InlineData(1, "BRL", 1, new string[] { "EUR" })]
        public void CurrencyTransaction_ReturnsOkResultAsync(int idUser, string OriginCurrency, decimal OriginValue, string[] DestinationCurrency)
        {
            // Act
            // Assert
        }
    }
}
