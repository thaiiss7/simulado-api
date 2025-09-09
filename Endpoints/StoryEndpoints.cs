using Microsoft.AspNetCore.Mvc;
using Simulado.UseCases.CreateStory;
using Simulado.UseCases.DeleteStory;

namespace Simulado.Endpoints;

public static class StoryEndpoints
{
    public static void ConfigureStoryEndpoints(this WebApplication app)
    {
        //mappost para criar historia
        app.MapPost("story", async (
            [FromBody] CreateStoryRequest request,
            [FromServices] CreateStoryUseCase useCase) => 
            {
                var result = await useCase.Do(request);
                if (result.IsSuccess)
                    return Results.Created(); 

                return Results.BadRequest(result.Reason);
            });

        //mapdelete para deletar historia
        app.MapDelete("story/{id}", async (string id, 
            HttpContext http,
            [FromServices]DeleteStoryUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(claim.Value);
            var storyId = Guid.Parse(id);
            var request = new DeleteStoryRequest(storyId, userId);
            var result = await useCase.Do(request);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Story not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok()
            };
        }).RequireAuthorization();
    }
}