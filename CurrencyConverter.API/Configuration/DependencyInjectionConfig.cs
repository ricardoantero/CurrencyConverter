using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Infra.Data.Context;
using CurrencyConverter.Infra.Data.Repositories;
using CurrencyConverter.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<SqlDbContext>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICurrenciesService, CurrenciesService>();
            services.AddScoped<ITransactionsService, TransactionsService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
