using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.ViewModels
{
    public class BaseViewModel
    {
        public virtual int Id { get; set; }
        [JsonIgnore]
        public virtual DateTime? CreateDate { get; set; }
        [JsonIgnore]
        public virtual bool Active { get; set; }
    }
}
