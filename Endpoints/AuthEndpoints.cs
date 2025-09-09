using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Simulado.Payloads;
using Simulado.UseCases.Login;

namespace Simulado.Endpoints;

public static class AuthEndpoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/auth", async
        (
            [FromServices] LoginUseCase useCase,
            [FromBody] LoginPayload payload) =>
            {
                var response = await useCase.Do(new UseCases.Login.LoginRequest(
                    payload.Login,
                    payload.Password
                ));

                if (response.IsSuccess)
                    return Results.Ok(response.Data);

                return Results.Unauthorized();
            });
    }
}