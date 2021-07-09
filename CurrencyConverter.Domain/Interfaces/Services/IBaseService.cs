using CurrencyConverter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.Interfaces.Services
{
    public interface IService<TViewModel> where TViewModel : BaseEntity
    {
        Task Add(TViewModel viewModel);
        Task Update(TViewModel viewModel);
        Task Delete(int id);
        Task<TViewModel> GetById(int id);
        Task<IEnumerable<TViewModel>> GetAll();
    }
}
