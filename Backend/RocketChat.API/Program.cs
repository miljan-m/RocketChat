using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using RocketChat.API.Hubs;
using RocketChat.Application.Interfaces;
using RocketChat.Application.Services;
using RocketChat.Infrastructure;
using RocketChat.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.BearerToken;

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
builder.Services.AddIdentityApiEndpoints<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

}).AddEntityFrameworkStores<DBContext>().AddApiEndpoints();

builder.Services.Configure<BearerTokenOptions>(IdentityConstants.BearerScheme, options =>
{
    options.Events = new BearerTokenEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.HttpContext.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                path.StartsWithSegments("/chat"))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<UserMapper>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactApp",
        builder => builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        );
});
builder.Services.AddSignalR();
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
app.UseCors("ReactApp");
app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<ApplicationUser>();
app.MapHub<ChatHub>("/chat");
app.MapControllers();

app.Run();


