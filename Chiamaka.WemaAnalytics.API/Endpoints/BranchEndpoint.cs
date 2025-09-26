using Chiamaka.WemaAnalytics.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Chiamaka.WemaAnalytics.API.Endpoints
{
    public static class BranchEndpoint
    {
        public static RouteGroupBuilder MapBranchGroup(this RouteGroupBuilder group)
        {
            group.MapPost("/create-branch", async (CreateBranchCommand command, [FromServices]ISender sender) =>
            {
                var result = await sender.Send(command);
                return result;
            })
            .WithDisplayName("Create branch").WithOpenApi();

            

            return group;
        }
    }
}
