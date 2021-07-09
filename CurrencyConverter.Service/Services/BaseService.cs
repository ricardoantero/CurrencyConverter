
using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Service.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper Mapper;
        protected readonly ILogger Logger;

        protected BaseService(IMapper mapper, ILogger logger)
        {
            Mapper = mapper;
            Logger = logger;
        }
    }
}
