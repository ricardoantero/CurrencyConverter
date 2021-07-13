using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyConverter.Domain.ViewModels
{
    public class TransactionsViewModel : BaseViewModel
    {
        public int UsersId { get; set; }
        public int CurrenciesId { get; set; }

        public string OriginCurrency { get; set; }
        public string DestinationCurrency { get; set; }
        public decimal OriginValue { get; set; }
        public decimal DestinationValue { get; set; }
        public decimal ConversionRate { get; set; }
        public DateTime ConversionDate { get; set; }

        [JsonIgnore]
        public UsersViewModel Users { get; set; }
        [JsonIgnore]
        public CurrenciesViewModel Currencies { get; set; }

        [JsonIgnore]
        public TransactionsDeserializeViewModel Deserialize { get; set; }
        public TransactionsErrorViewModel Error { get; set; }
    }
    public class TransactionsDeserializeViewModel
    {
        public bool success { get; set; }
        public int timestamp { get; set; }
        public string @base { get; set; }
        public string date { get; set; }
        public Dictionary<string, string> rates { get; set; }
        public TransactionsErrorViewModel error { get; set; }
    }

    public class TransactionsErrorViewModel
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}
