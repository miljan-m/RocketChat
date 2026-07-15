using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using RocketChat.Application.Interfaces;

namespace RocketChat.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IUserService _userService;

        public ChatHub(IUserService userService)
        {
            _userService = userService;
        }

        public async Task SendMessage(string message, string username)
        {
            var receieverUserId = await _userService.GetUserIdByUserName(username) ?? throw new HubException("Receiever Id is NULL");
            await Clients.User(receieverUserId).SendAsync("ReceivePrivateMessage", Context.UserIdentifier, message);
        }
    }
}