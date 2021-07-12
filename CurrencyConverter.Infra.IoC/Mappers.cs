using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace CurrencyConverter.Infra.IoC
{
    public static class Mappers
    {
        public static void DependecyMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(System.Reflection.Assembly.Load("CurrencyConverter.Service"));
        

        }
    }
}
