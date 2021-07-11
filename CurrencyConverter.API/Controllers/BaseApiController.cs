using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Controllers
{
    public abstract class BaseAPIController<TViewModel> : ControllerBase where TViewModel : BaseViewModel
    {
        protected readonly IBaseService<TViewModel> Service;
        protected readonly ILogger Logger;

        public BaseAPIController(IBaseService<TViewModel> service, ILogger logger)
        {
            Service = service;
            Logger = logger;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TViewModel value)
        {
            Logger.Information("log {param1}", new { Return = $"Method Post", model = value, Error = "" });

            await Service.Add(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            Logger.Information("log {param1}", new { Return = $"Method Delete", id = id, Error = "" });

            await Service.Delete(id);

            return Ok();
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TViewModel value)
        {
            Logger.Information("log {param1}", new { Return = $"Method Put", model = value, Error = "" });

            await Service.Update(value);

            return Ok();
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            Logger.Information("log {param1}", new { Return = $"Method Get", id = id, Error = "" });
            var model = await Service.GetById(id);

            if (model == null)
                return NotFound("Register not found");

            return Ok(model);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            Logger.Information("log {param1}", new { Return = $"Method Get", Error = "" });
            var list = await Service.GetAll();

            return Ok(list);
        }
    }
}
