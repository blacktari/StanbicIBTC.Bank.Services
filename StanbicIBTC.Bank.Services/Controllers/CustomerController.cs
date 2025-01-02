using Microsoft.AspNetCore.Mvc;
using StanbicIBTC.Bank.Services.Models;
using Microsoft.Extensions.Logging;
using StanbicIBTC.Bank.Services.Services.Interfaces.Customer;

namespace StanbicIBTC.Bank.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpPost("CreateCustomer")]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] CustomerCreationRequest request)
        {
            if (request == null)
            {
                _logger.LogWarning("Customer creation request was null.");
                return BadRequest("Invalid customer data.");
            }

            try
            {
                var customer = await _customerService.CreateCustomerAsync(request);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the customer.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
