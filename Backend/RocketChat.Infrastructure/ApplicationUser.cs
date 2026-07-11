using Microsoft.AspNetCore.Identity;

namespace RocketChat.Infrastructure
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}