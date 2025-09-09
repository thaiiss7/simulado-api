using System.ComponentModel.DataAnnotations;
using Simulado.Validations;

namespace Simulado.UseCases.CreateStory;

public record CreateStoryRequest
{
    [Required]
    public required string Title { get; init; }
    [Required]
    [TextAttributes(MaxLines = 100, MaxWords = 1000, MaxChar = 600)] //valores customizados
    public required string Text { get; init; }
    [Required]
    public Guid AuthorId { get; init; }
}
