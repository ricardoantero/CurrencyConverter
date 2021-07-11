using AutoMapper;
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
    public class TransactionsService : BaseService, ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<TransactionsViewModel> _validator;

        public TransactionsService(ITransactionsRepository transactionsRepository, IUsersRepository usersRepository, IValidator<TransactionsViewModel> validator, IMapper mapper, ILogger logger) : base(mapper, logger)
        {
            _transactionsRepository = transactionsRepository;
            _usersRepository = usersRepository;
            _validator = validator;
        }
        public async Task Add(TransactionsViewModel viewModel)
        {
            Logger.ForContext("data", viewModel, true).Information("Insert Transaction");

            await _validator.ValidateAndThrowAsync(viewModel);

            var entity = Mapper.Map<Transactions>(viewModel);

            await _transactionsRepository.Add(entity);
        }

        public Task Delete(int id)
        {
            return _transactionsRepository.Delete(id);
        }

        public async Task<IEnumerable<TransactionsViewModel>> GetAll()
        {
            var entities = await _transactionsRepository.GetAll();

            return Mapper.Map<IEnumerable<TransactionsViewModel>>(entities);
        }

        public async Task<TransactionsViewModel> GetById(int id)
        {
            var entity = await _transactionsRepository.GetByIdAsync(id);

            return Mapper.Map<TransactionsViewModel>(entity);
        }

        public async Task Update(TransactionsViewModel viewModel)
        {
            await _validator.ValidateAndThrowAsync(viewModel);

            var entity = Mapper.Map<Transactions>(viewModel);

            await _transactionsRepository.Update(entity);
        }
    }
}
