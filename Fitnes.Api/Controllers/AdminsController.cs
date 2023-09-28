using AutoMapper;
using Fitnes.Application.Models.UpdateDto;
using Fitnes.Application.UseCases.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fitnes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public AdminsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateAdminDto dto)
        {
            try
            {
                CreateUserCommand command = mapper.Map<CreateUserCommand>(dto);
                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromForm] UpdateAdminDto dto)
        {
            try
            {
                UpdateUserCommand command = mapper.Map<UpdateUserCommand>(dto);
                return Ok(await mediator.Send(command));
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
    }
}
