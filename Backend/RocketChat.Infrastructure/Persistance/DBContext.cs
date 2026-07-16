using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RocketChat.Domain.Models;

namespace RocketChat.Infrastructure.Persistance
{
    public class DBContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                    .HasMany(u => u.SentMessages)
                    .WithOne()
                    .HasForeignKey(m => m.SenderUsername)
                    .HasPrincipalKey(u => u.UserName)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.ReceivedMessages)
                .WithOne()
                .HasForeignKey(m => m.ReceiverUsername)
                .HasPrincipalKey(u => u.UserName)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}