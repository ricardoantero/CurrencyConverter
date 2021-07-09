using AutoMapper;
using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<UsersViewModel, Users>().ReverseMap();
            CreateMap<CurrenciesViewModel, Currencies>().ReverseMap();
            CreateMap<TransactionsViewModel, Transactions>().ReverseMap();
        }
    }
}
