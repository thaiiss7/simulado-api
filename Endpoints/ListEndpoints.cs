using Simulado.UseCases.EditList;
using Simulado.UseCases.GetList;

namespace Simulado.Endpoints;

public static class ListEndpoints
{
    public static void ConfigureListEndpoints(this WebApplication app)
    {
        //mapget para acessar lista
        app.MapGet("list/{title}", async (
            string title,
            [FromServices] GetListUseCase useCase) =>
            {
                var request = new GetListRequest(title);
                var result = await useCase.Do(request);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "List not found") => Results.NotFound(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };

            });

        //mapput para editar lista
        app.MapPut("/{listId}/{storyId}", async (
            string listId,
            string storyId,
            HttpContext http,
            [FromServices] EditlistUseCase useCase) =>
            {
                var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
                var userId = Guid.Parse(claim.Value);
                var storyId = Guid.Parse(storyId);
                var listId = Guid.Parse(listId);
                var request = await new EditListRequest(listId, userId, storyId);
                var result = await useCase.Do(request);

                return (result.IsSuccess, result.Reason) switch
                {
                    (false, "List not found") => Results.NotFound(),
                    (false, "Unathorized") => Results.Unathorized(),
                    (false, _) => Results.BadRequest(),
                    (true, _) => Results.Ok(result.Data)
                };

            }).RequireAuthorization();
    }
}