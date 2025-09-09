using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Simulado.Endpoints;
using Simulado.Entities;
using Simulado.Services.JWT;
using Simulado.UseCases.CreateStory;
using Simulado.UseCases.DeleteStory;
using Simulado.UseCases.EditList;
using Simulado.UseCases.GetList;
using Simulado.UseCases.Login;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SimuladoDbContext>(options =>
{
    var myBd = Environment.GetEnvironmentVariable("SQL_CONNECTION") ?? "SimuladoDB";
    options.UseInMemoryDatabase(myBd);
});

builder.Services.AddSingleton<IJWTService, JWTService>();

builder.Services.AddTransient<CreateStoryUseCase>();
builder.Services.AddTransient<DeleteStoryUseCase>();
builder.Services.AddTransient<EditListUseCase>();
builder.Services.AddTransient<GetListUseCase>();
builder.Services.AddTransient<LoginUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "simulado-api",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureAuthEndpoints();
app.ConfigureListEndpoints();
app.ConfigureStoryEndpoints();

app.Run();
