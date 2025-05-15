using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Context")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.User.AllowedUserNameCharacters = string.Empty;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.SignIn.RequireConfirmedEmail = true;
})
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
