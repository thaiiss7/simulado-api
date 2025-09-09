using System.ComponentModel.DataAnnotations;

namespace Simulado.Payloads;

public class LoginPayload
{
    [Required]
    [MaxLength(256)]
    public required string Login { get; init; }
    [Required]
    [MaxLength(256)]
    public required string Password { get; init; }
}