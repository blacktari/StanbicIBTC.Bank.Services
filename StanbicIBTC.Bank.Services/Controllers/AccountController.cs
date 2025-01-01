using Microsoft.AspNetCore.Mvc;
using StanbicIBTC.Bank.Services.Models;
using StanbicIBTC.Bank.Services.Services;
using StanbicIBTC.Bank.Services.Interfaces;
using StanbicIBTC.Bank.Services.Exceptions;
using Microsoft.Extensions.Logging;
using StanbicIBTC.Bank.Services.DTOs.Request;

namespace StanbicIBTC.Bank.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost("CreateAccount")]
        public ActionResult<Account> CreateAccount([FromBody] AccountCreationRequest request)
        {
            if (request == null)
            {
                _logger.LogWarning("Account creation request was null.");
                return BadRequest("Invalid account creation data.");
            }

            try
            {
                var account = _accountService.CreateAccount(request);  // Pass the request object directly
                return Ok(account); // 200 OK
            }
            catch (AccountCreationException ex)
            {
                _logger.LogError(ex, "Account creation failed.");
                return StatusCode(ex.StatusCode, ex.Message); // Return the custom error status code and message
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the account creation request.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
