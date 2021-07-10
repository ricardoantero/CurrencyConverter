using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infra.IoC.API
{
   public class CurrenciesConverterAPI
    {
        public async Task<IActionResult> RetAPI()
        {
            List<dynamic> reservationList = new List<dynamic>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://api.exchangeratesapi.io/v1/latest?access_key=0ce869d9bebdb1a32bfc3299fe1c5a51&symbols=USD,AUD,CAD,PLN,MXN&format=1"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<dynamic>>(apiResponse);
                }
            }
            return (IActionResult)reservationList;
        }
    }
}
