using AutoMapper;
using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CurrencyConverter.Service.Mappers
{
    public class CurrenciesMappers : Profile
    {
        public CurrenciesMappers()
        {
            CreateMap<CurrenciesViewModel, Currencies>().ReverseMap();
            CreateMap<Expression<Func<CurrenciesViewModel, bool>>, Expression<Func<Currencies, bool>>>().ReverseMap();
        }
    }
}
