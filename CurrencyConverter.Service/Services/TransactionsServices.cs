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
    public class TransactionsService : BaseService, ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IValidator<TransactionsViewModel> _validator;

        public TransactionsService(ITransactionsRepository TransactionsRepository, IValidator<TransactionsViewModel> validator, IMapper mapper, ILogger logger) : base(mapper, logger)
        {
            _transactionsRepository = TransactionsRepository;
            _validator = validator;
        }
        public Task Add(TransactionsViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TransactionsViewModel>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TransactionsViewModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(TransactionsViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
