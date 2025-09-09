using Microsoft.EntityFrameworkCore;
using Simulado.Entities;

namespace Simulado.UseCases.GetList;

public class GetListUseCase(SimuladoDbContext ctx)
{
    public async Task<Result<GetListResponse>> Do(GetListRequest request)
    {
        var list = await ctx.Lists
        .Include(l => l.Owner)
            .ThenInclude(o => o.Username)
        .FirstOrDefaultAsync(l => l.Title == request.Title);

        if (list is null)
            return Result<GetListResponse>.Fail("List not found");

        var response = new GetListResponse
        (
            list.Title,
            list.LastUpdated,
            from s in list.Stories
            select new StoriesData
            (
                s.Title,
                s.Author.Username
            )
        );

        return Result<GetListResponse>.Success(response);
    }
}