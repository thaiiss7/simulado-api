using Microsoft.AspNetCore.Mvc;
using Simulado.UseCases.CreateStory;

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
    }
}