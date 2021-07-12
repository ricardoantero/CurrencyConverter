using AutoMapper;
using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.Interfaces;
using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Domain.ViewModels;
using FluentValidation;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        public async Task Add(UsersViewModel viewModel)
        {
            await _validator.ValidateAndThrowAsync(viewModel);

            var entity = Mapper.Map<Users>(viewModel);

            await _usersRepository.Add(entity);
        }

        public Task Delete(int id)
        {
            return _usersRepository.Delete(id);
        }

        public async Task<IEnumerable<UsersViewModel>> GetAll(Expression<Func<UsersViewModel, bool>> expression = null)
        {
            if (expression == null)
            {
                return Mapper.Map<IEnumerable<UsersViewModel>>(await _usersRepository.GetAll());
            }
            return Mapper.Map<IEnumerable<UsersViewModel>>(await _usersRepository.GetAll(Mapper.Map<Expression<Func<Users, bool>>>(expression)));
        }

        public async Task<UsersViewModel> GetById(int id)
        {
            var entity = await _usersRepository.GetByIdAsync(id);

            return Mapper.Map<UsersViewModel>(entity);
        }

        public async Task Update(UsersViewModel viewModel)
        {
            await _validator.ValidateAndThrowAsync(viewModel);

            var entity = Mapper.Map<Users>(viewModel);

            await _usersRepository.Update(entity);
        }
    }
}
