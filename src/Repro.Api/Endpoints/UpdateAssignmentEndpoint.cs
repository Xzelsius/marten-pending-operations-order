using Marten;
using Microsoft.AspNetCore.Mvc;
using Repro.Api.Domain;
using Wolverine.Http;

namespace Repro.Api.Endpoints;

public static class UpdateAssignmentEndpoint
{
    [WolverinePost("/update-assignment/{id}")]
    [EmptyResponse]
    public static void Update([FromRoute] Guid id, UpdateAssignmentRequest request, IDocumentSession session)
    {
        Guid ouId = RelatedDataProvider.RootOu;

        Guid[] userIds = Enumerable
            .Range(1, request.AmountOfUsers)
            .Select(x => Guid.NewGuid())
            .ToArray();

        Guid[] groupIds = [];

        Guid[] roleIds = [RelatedDataProvider.RoleId];

        var updated = new RoleAssignmentUpdated(id, ouId, userIds, groupIds, roleIds, request.AllowInheritance);
        session.Events.Append(updated.RoleAssignmentId, updated);
    }
}

public record UpdateAssignmentRequest(int AmountOfUsers, bool AllowInheritance);
