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
    public class UsersService : BaseService, IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IValidator<UsersViewModel> _validator;

        public UsersService(IUsersRepository UsersRepository, IValidator<UsersViewModel> validator, IMapper mapper, ILogger logger) : base(mapper, logger)
        {
            _usersRepository = UsersRepository;
            _validator = validator;
        }
        public Task Add(UsersViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UsersViewModel>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<UsersViewModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(UsersViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
