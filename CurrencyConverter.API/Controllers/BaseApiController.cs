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
            await Service.Add(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await Service.Delete(id);

            return Ok();
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TViewModel value)
        {
            await Service.Update(value);

            return Ok();
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var model = await Service.GetById(id);

            if (model == null)
                return NotFound("Register not found");

            return Ok(model);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            Logger.ForContext("UserName", "User").Information("log {param1}", new { Id = 1, Error = "Error" });

            var list = await Service.GetAll();

            return Ok(list);
        }
    }
}
