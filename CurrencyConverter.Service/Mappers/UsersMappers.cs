using AutoMapper;
using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Service.Mappers
{
    public class UsersMapper : Profile
    {
        public UsersMapper()
        {
            CreateMap<UsersViewModel, Users>().ReverseMap();
        }
    }
}
