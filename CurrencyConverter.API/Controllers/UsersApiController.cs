using CurrencyConverter.Domain.Interfaces.Services;
using CurrencyConverter.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : BaseAPIController<UsersViewModel>
    {
        private readonly ITransactionsService _transactionsService;
        public UsersApiController(IUsersService service, ITransactionsService transactionsService, ILogger logger) : base(service, logger)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet("userstransaction/{id}")]
        public async Task<ActionResult<TransactionsViewModel>> UsersTransaction(int id)
        {
            try
            {
                var usersViewModel = new UsersViewModel();

                var itemUsersViewModel = await Service.GetById(id);

                if (usersViewModel == null)
                {
                    Logger.Information("log {param1}", new { Return = $"Method UsersTransaction", Error = "User not found" });
                    return Notification(null, "User not found", false);
                }

                List<TransactionsViewModel> listTransactionsViewModel = (List<TransactionsViewModel>)await _transactionsService.FindUserTransactions(id);

                return Ok(listTransactionsViewModel);
            }
            catch (Exception ex)
            {
                Logger.Information("log {param1}", new { Return = $"Method UsersTransaction", Error = ex.Message });
                return Problem();
            }
        }

        protected OkObjectResult Notification(string code, string message, bool sucesss = true) => Ok(new
        {
            success = sucesss,
            data = new UsersErrorViewModel { code = code, message = message }
        });
    }
}
