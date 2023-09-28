using AutoMapper;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Cards.Commands;
using Fitnes.Application.UseCases.Cards.Queries;
using Fitnes.Application.UseCases.Users.Commands;
using Fitnes.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitnes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMediator mediator;
        public CardsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCardsCommand command)
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
        public async Task<IActionResult> Update([FromBody] UpdateCardsCommand command)
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
        [Route("{CardId}")]
        public async Task<IActionResult> Delete([FromRoute] int CardId)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteCardsCommand(CardId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllCardsQuery()));
        }

        [HttpGet]
        [Route("{CardId}")]
        public async Task<IActionResult> Get([FromRoute] int CardId)
        {
            return Ok(await mediator.Send(new GetCardsQuery(CardId)));
        }
    }
}
