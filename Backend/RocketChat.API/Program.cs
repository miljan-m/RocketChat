using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

}).AddEntityFrameworkStores<DBContext>().AddApiEndpoints();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);


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

var app = builder.Build();
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/login" && context.Request.Method == "POST")
    {
        // Omogućava čitanje body-ja više puta za logovanje
        context.Request.EnableBuffering();
    }
    await next();
});
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

app.MapControllers();

app.Run();


