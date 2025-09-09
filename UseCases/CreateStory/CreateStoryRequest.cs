using System.ComponentModel.DataAnnotations;

namespace Simulado.UseCases.CreateStory;

public record CreateStoryRequest
{
    [Required]
    public required string Title { get; init; }
    [Required]
    [MaxLength(6000)]
    public required string Text { get; init; }
    public Guid AuthorId { get; init; }
}
