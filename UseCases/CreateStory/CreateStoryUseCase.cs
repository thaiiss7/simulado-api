using Simulado.Entities;

namespace Simulado.UseCases.CreateStory;

public class CreateStoryUseCase(SimuladoDbContext ctx)
{
    public async Task<Result<CreateStoryResponse>> Do(CreateStoryRequest request)
    {
        var story = new Story
        {
            Title = request.Title,
            Text = request.Text,
            AuthorId = request.AuthorId
        };

        ctx.Stories.Add(story);
        await ctx.SaveChangesAsync();
        return Result<CreateStoryResponse>.Success(new(story.ID));
    }
}