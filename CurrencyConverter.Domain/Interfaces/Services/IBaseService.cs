using CurrencyConverter.Domain.Entities;
using CurrencyConverter.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Interfaces.Services
{
    public interface IBaseService<TViewModel> where TViewModel : BaseViewModel
    {
        Task Add(TViewModel viewModel);
        Task Update(TViewModel viewModel);
        Task Delete(int id);
        Task<TViewModel> GetById(int id);
        Task<IEnumerable<TViewModel>> GetAll(Expression<Func<TViewModel, bool>> expression = null);
    }
}
