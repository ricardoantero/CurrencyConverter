using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<TransactionsViewModel> Transactions { get; set; }
    }
}
