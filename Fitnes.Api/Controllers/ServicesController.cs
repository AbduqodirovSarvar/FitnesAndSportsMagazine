using Fitnes.Application.UseCases.Services.Commands;
using Fitnes.Application.UseCases.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitnes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminActions")]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ServicesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateServiceCommand command)
        {
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateServiceCommand command)
        {
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{ServiceId}")]
        public async Task<IActionResult> Delete(int ServiceId)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteServiceCommand(ServiceId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{ServiceId}")]
        public async Task<IActionResult> Get([FromRoute] int ServiceId)
        {
            return Ok(await mediator.Send(new GetServiceQuery(ServiceId)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllServiceQuery()));
        }
    }
}
