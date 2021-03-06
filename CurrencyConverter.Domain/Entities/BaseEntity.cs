using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyConverter.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual bool Active { get; set; }
    }
}
