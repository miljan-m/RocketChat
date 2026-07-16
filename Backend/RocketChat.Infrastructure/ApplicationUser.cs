using Microsoft.AspNetCore.Identity;
using RocketChat.Domain.Models;

namespace RocketChat.Infrastructure
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public ICollection<Message>? SentMessages { get; set; }
        public ICollection<Message>? ReceivedMessages { get; set; }

    }
}