using Microsoft.EntityFrameworkCore;
using Simulado.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SimuladoDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

var app = builder.Build();

app.Run();
