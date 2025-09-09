using Microsoft.EntityFrameworkCore;
using Simulado.Entities;

namespace Simulado.UseCases.EditList;

public class EditListUseCase(SimuladoDbContext ctx)
{
    public async Task<Result<EditListResponse>> Do(EditListRequest request)
    {
        var list = await ctx.Lists.FirstOrDefaultAsync(l => l.ID == request.ListId);

        if (list is null)
            return Result<EditListResponse>.Fail("List not found");

        if (list.OwnerId != request.UserId)
            return Result<EditListResponse>.Fail("You are not the owner of this list");

        var story = await ctx.Stories.FirstOrDefaultAsync(s => s.ID == request.StoryId);
        list.Stories.Add(story);
        await ctx.SaveChangesAsync();

        return Result<EditListResponse>.Success(null);
    }
}