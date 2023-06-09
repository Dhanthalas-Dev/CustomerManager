﻿using CustomerManagerApplication.IO.Commands;
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

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var query = new GetCustomerByIdQuery()
            {
                CustomerId = id
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteCustomerCommand
            {
                Id = id
            });
            return Ok();
        }
    }
}
