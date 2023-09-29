using Fitnes.Application.UseCases.Orders.Commands;
using Fitnes.Application.UseCases.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitnes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command)
        {
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommand command)
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
        [Route("{OrderID}")]
        public async Task<IActionResult> Delete(int OrderID)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteOrderCommand(OrderID)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("{OrderID}")]
        public async Task<IActionResult> Get([FromRoute] int OrderID)
        {
            return Ok(await mediator.Send(new GetOrderQuery(OrderID)));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllOrderQuery()));
        }
    }
}
