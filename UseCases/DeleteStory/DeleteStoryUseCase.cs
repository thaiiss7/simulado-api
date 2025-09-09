using Microsoft.EntityFrameworkCore;
using Simulado.Entities;

namespace Simulado.UseCases.DeleteStory;

public class DeleteStoryUseCase(SimuladoDbContext ctx)
{
    public async Task<Result<DeleteStoryResponse>> Do(DeleteStoryRequest request)
    {
        var story = await ctx.Stories.FirstOrDefaultAsync(s => s.ID == request.StoryId);

        if (story.AuthorId != request.UserId)
            return Result<DeleteStoryResponse>.Fail("You are not the author of this story");

        if (story is null)
            return Result<DeleteStoryResponse>.Fail("Story not found");

        ctx.Stories.Remove(story);
        await ctx.SaveChangesAsync();

        return Result<DeleteStoryResponse>.Success(null);
    }
}