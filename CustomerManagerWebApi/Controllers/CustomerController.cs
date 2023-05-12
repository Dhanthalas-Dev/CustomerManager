using CustomerManagerApplication.IO.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagerWebApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetCustomersQuery());
            return Ok(result);
        }
    }
}
