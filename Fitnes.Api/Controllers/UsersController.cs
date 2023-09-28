using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.UpdateDto;
using Fitnes.Application.Models.ViewModels;
using Fitnes.Application.UseCases.Users.Commands;
using Fitnes.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitnes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public UsersController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateUserCommand command)
        {
            try
            {
                var user = await mediator.Send(command);
                return Ok(mapper.Map<UserViewModel>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromForm] UpdateUserCommand command)
        {
            try
            {
                var user = await mediator.Send(command);
                return Ok(mapper.Map<UserViewModel>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{UserId}")]
        public async Task<IActionResult> Delete([FromRoute] int UserId)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteUserCommand(UserId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var users = await mediator.Send(new GetAllUserQuery());
            return Ok(mapper.Map<List<UserViewModel>>(users));
        }

        [HttpGet]
        [Route("{UserId}")]
        public async Task<IActionResult> Get([FromRoute] int UserId)
        {
            var user = await mediator.Send(new GetUserQuery(UserId));
            return Ok(mapper.Map<UserViewModel>(user));
        }
    }
}
