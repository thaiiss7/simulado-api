namespace Simulado.UseCases.EditList;

public record EditListRequest
(
    Guid ListId,
    Guid UserId,
    Guid StoryId
);