using AutoMapper;
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
    public class TeachersController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public TeachersController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateTeacherDto dto)
        {
            try
            {
                CreateUserCommand command = mapper.Map<CreateUserCommand>(dto);
                var user = await mediator.Send(command);
                return Ok(mapper.Map<TeacherViewModel>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromForm] UpdateTeacherDto dto)
        {
            try
            {
                UpdateUserCommand command = mapper.Map<UpdateUserCommand>(dto);
                var user = await mediator.Send(command);
                return Ok(mapper.Map<TeacherViewModel>(user));
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
            users = users.Where(x => x.Role == Domain.Enums.UserRole.Teacher).ToList();
            return Ok(mapper.Map<List<TeacherViewModel>>(users));
        }

        [HttpGet]
        [Route("{UserId}")]
        public async Task<IActionResult> Get([FromRoute] int UserId)
        {
            var user = await mediator.Send(new GetUserQuery(UserId));
            if (user.Role != Domain.Enums.UserRole.Teacher)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TeacherViewModel>(user));
        }
    }
}
