using Chiamaka.WemaAnalytics.Application.Commands;
using Chiamaka.WemaAnalytics.Application.Queries;
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

            group.MapPost("/update-branch", async (UpdateBranchCommand command, [FromServices]ISender sender) =>
            {
                var result = await sender.Send(command);
                return result;
            })
            .WithDisplayName("update branch").WithOpenApi();

            group.MapPost("/deactivate-branch", async (DeactivateBranchCommand command, [FromServices]ISender sender) =>
            {
                var result = await sender.Send(command);
                return result;
            })
            .WithDisplayName("deactivate branch").WithOpenApi();

            group.MapPost("/delete-branch", async (DeleteBranchCommand command, [FromServices]ISender sender) =>
            {
                var result = await sender.Send(command);
                return result;
            })
            .WithDisplayName("delete branch").WithOpenApi();

            group.MapPost("/getbranchbyid", async (GetBranchByIdQuery query, [FromServices]ISender sender) =>
            {
                var result = await sender.Send(query);
                return result;
            })
            .WithDisplayName("getbranchbyid branch").WithOpenApi();

            group.MapPost("/searchbranches", async (SearchBranchesQuery query, [FromServices]ISender sender) =>
            {
                var result = await sender.Send(query);
                return result;
            })
            .WithDisplayName("searchbranches").WithOpenApi();


            return group;
        }
    }
}
