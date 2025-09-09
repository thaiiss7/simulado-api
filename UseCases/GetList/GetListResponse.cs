using System.Data.SqlTypes;

namespace Simulado.UseCases.GetList;

public record StoriesData
(
    string StoryTitle,
    string AuthorName
);
public record GetListResponse
(
    string Title,
    DateTime LatsUpdated,
    IEnumerable<StoriesData> Stories
);