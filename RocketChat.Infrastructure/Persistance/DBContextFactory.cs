using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RocketChat.Infrastructure.Persistance;

public class DBContextFactory : IDesignTimeDbContextFactory<DBContext>
{
    public DBContext CreateDbContext(string[] args)
    {
        var options=new DbContextOptionsBuilder<DbContext>();
        options.UseSqlServer("Server=DESKTOP-QLQGED2\\SQLEXPRESS01;Database=RocketChat;Trusted_Connection=True;TrustServerCertificate=True");
        return new DBContext(options.Options);
    }

    
}