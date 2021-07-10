using AutoMapper.Configuration;
using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Domain.ViewModels;
using CurrencyConverter.Infra.Data.Context;
using CurrencyConverter.Infra.Data.Repositories;
using CurrencyConverter.Service.Services;
using CurrencyConverter.Service.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;

namespace CurrencyConverter.Infra.IoC
{
    public static class Registers
    {
        public static void DependecyRegister(this IServiceCollection services)
        {
            //data
            services.AddScoped<SqlDbContext>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICurrenciesService, CurrenciesService>();
            services.AddScoped<ITransactionsService, TransactionsService>();

            //validators
            services.AddScoped<IValidator<UsersViewModel>, UsersValidator>();
            services.AddScoped<IValidator<CurrenciesViewModel>, CurrenciesValidator>();
            services.AddScoped<IValidator<TransactionsViewModel>, TransactionsValidator>();
        }
    }
}
