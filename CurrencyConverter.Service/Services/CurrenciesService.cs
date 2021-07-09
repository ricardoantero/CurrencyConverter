using AutoMapper;
using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Domain.ViewModels;
using FluentValidation;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.Service.Services
{
    public class CurrenciesService : BaseService, ICurrenciesService
    {
        private readonly ICurrenciesRepository _currenciesRepository;
        private readonly IValidator<CurrenciesViewModel> _validator;

        public CurrenciesService(ICurrenciesRepository CurrenciesRepository, IValidator<CurrenciesViewModel> validator, IMapper mapper, ILogger logger) : base(mapper, logger)
        {
            _currenciesRepository = CurrenciesRepository;
            _validator = validator;
        }

        public Task Add(CurrenciesViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CurrenciesViewModel>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<CurrenciesViewModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(CurrenciesViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
