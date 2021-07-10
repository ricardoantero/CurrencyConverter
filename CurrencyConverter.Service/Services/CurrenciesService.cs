﻿using AutoMapper;
using CurrencyConverter.Domain.Entities;
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

        public async Task Add(CurrenciesViewModel viewModel)
        {
            Logger.ForContext("data", viewModel, true).Information("Insert Currency");

            await _validator.ValidateAndThrowAsync(viewModel);

            var entity = Mapper.Map<Currencies>(viewModel);

            await _currenciesRepository.Add(entity);
        }

        public Task Delete(int id)
        {
            return _currenciesRepository.Delete(id);
        }

        public async Task<IEnumerable<CurrenciesViewModel>> GetAll()
        {
            var entities = await _currenciesRepository.GetAll();

            return Mapper.Map<IEnumerable<CurrenciesViewModel>>(entities);
        }

        public async Task<CurrenciesViewModel> GetById(int id)
        {
            var entity = await _currenciesRepository.GetByIdAsync(id);

            return Mapper.Map<CurrenciesViewModel>(entity);
        }

        public async Task Update(CurrenciesViewModel viewModel)
        {
            await _validator.ValidateAndThrowAsync(viewModel);

            var entity = Mapper.Map<Currencies>(viewModel);

            await _currenciesRepository.Update(entity);
        }

    }
}
