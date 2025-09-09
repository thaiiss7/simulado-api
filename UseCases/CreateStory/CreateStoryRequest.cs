using System.ComponentModel.DataAnnotations;

namespace Simulado.UseCases.CreateStory;

public record CreateStoryRequest
{
    [Required]
    public required string Title { get; init; }
    [Required]
    [TextAttribute]
    public required string Text { get; init; }
    [Required]
    public Guid AuthorId { get; init; }
}
