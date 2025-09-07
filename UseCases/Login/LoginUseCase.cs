using Microsoft.EntityFrameworkCore;
using Simulado.Entities;
using Simulado.Services.JWT;

namespace Simulado.UseCases.Login;

public class LoginUseCase
(
    SimuladoDbContext ctx,
    IJWTService jwt
)
{
    public async Task<Result<LoginResponse>> Do(LoginRequest request)
    {
        var profile = await ctx.Profiles.FirstOrDefaultAsync(
            p => p.Email == request.Login || p.Username == request.Login
        );
        if (profile is null)
            return Result<LoginResponse>.Fail("Missing Profile");

        if (profile.Password != request.Password)
            return Result<LoginResponse>.Fail("Invalid Password");

        var token = jwt.CreateToken(new ProfileToAuth
        {
            ID = profile.ID,
            Username = profile.Username,
            Email = profile.Email
        });

        var response = new LoginResponse(token);
        return Result<LoginResponse>.Success(response);
    }
}