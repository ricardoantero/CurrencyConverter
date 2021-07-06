using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

    }
}
