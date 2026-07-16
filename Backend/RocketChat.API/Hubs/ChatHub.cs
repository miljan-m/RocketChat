using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using RocketChat.Application.Interfaces;
using RocketChat.Domain.Models;

namespace RocketChat.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        public ChatHub(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task SendMessage(string message, string receiverUsername, string senderUsername)
        {
            var receieverUserId = await _userService.GetUserIdByUserName(receiverUsername) ?? throw new HubException("Receiever Id is NULL");
            var m = new Message
            {
                MessageId = new Guid(),
                MessageText = message,
                ReceiverUsername = receiverUsername,
                SenderUsername = senderUsername
            };
            await _messageService.SaveMessage(m);
            await Clients.User(receieverUserId).SendAsync("ReceivePrivateMessage", Context.UserIdentifier, message);
        }
    }
}