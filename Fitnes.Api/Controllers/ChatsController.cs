using AutoMapper;
using Fitnes.Application.Interfaces;
using Fitnes.Application.Models.CreateDto;
using Fitnes.Application.UseCases.Chats.Commands;
using Fitnes.Application.UseCases.Chats.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fitnes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IFileSaveToFolder fileSaveToFolder;
        public ChatsController(IMediator mediator, IMapper mapper, IFileSaveToFolder fileSaveToFolder)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.fileSaveToFolder = fileSaveToFolder;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateMessageDto dto)
        {
            try
            {
                CreateMessageCommand command = mapper.Map<CreateMessageCommand>(dto);
                if (dto.File != null && dto.Type == Domain.Enums.MessageType.File)
                {
                    command.MsgOrFileName = await fileSaveToFolder.SaveToFolderAsync(dto.File);
                }
                else if (dto.Text != null && dto.Type == Domain.Enums.MessageType.Text)
                {
                    command.MsgOrFileName = dto.Text;
                }

                return Ok(await mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{MessageId}")]
        public async Task<IActionResult> Delete(int MessageId)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteMessageCommand(MessageId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{ChatId}")]
        public async Task<IActionResult> Get([FromRoute] int ChatId)
        {
            return Ok(await mediator.Send(new GetChatQuery(ChatId)));
        }
        [Authorize(Policy = "AdminAction")]
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllChatsQuery()));
        }
    }
}
