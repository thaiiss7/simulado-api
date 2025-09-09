namespace Simulado.UseCases.DeleteStory;

public record DeleteStoryRequest
(
    Guid StoryId,
    Guid UserId
);