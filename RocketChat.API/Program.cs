using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RocketChat.Application.Interfaces;
using RocketChat.Application.Services;
using RocketChat.Infrastructure;
using RocketChat.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DBContext>(options =>
{
    var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(ConnectionString);
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>().AddEntityFrameworkStores<DBContext>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<UserMapper>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
   {
       options.SwaggerEndpoint("/openapi/v1.json", "RocketChat API v1");
   });
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();


