using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using RocketChat.Application.Interfaces;
using RocketChat.Domain.Models;

namespace RocketChat.API.Controllers
{

    [ApiController]
    [Route("message")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var messages = await _messageService.GetAllMessages();
            if (messages.Any()) return Ok(messages);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SaveMessage([FromBody] Message message)
        {
            await _messageService.SaveMessage(message);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteConversation([FromQuery] string receiverUsername, [FromQuery] string senderUsername)
        {

            var result = await _messageService.DeleteConversation(receiverUsername, senderUsername);

            if (result) return Ok();
            else return NotFound();

        }

    }
}