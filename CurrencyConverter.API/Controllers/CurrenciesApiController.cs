using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrenciesApiController : BaseAPIController<CurrenciesViewModel>
    {
        public CurrenciesApiController(ICurrenciesService service, ILogger logger) : base(service, logger) { }
    }
}