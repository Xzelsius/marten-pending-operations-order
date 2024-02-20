namespace Repro.Api.Endpoints;

using Marten;
using Repro.Api.Domain;
using Wolverine.Http;

public static class CreateAssignmentEndpoint
{
    [WolverinePost("/create-assignment")]
    public static CreateAssignmentResponse Create(CreateAssignmentRequest request, IDocumentSession session)
    {
        Guid ouId = RelatedDataProvider.RootOu;

        Guid[] userIds = request.UserIds;

        Guid[] groupIds = [];

        Guid[] roleIds = [RelatedDataProvider.RoleId];

        var created = new RoleAssignmentCreated(Guid.NewGuid(), ouId, userIds, groupIds, roleIds, request.AllowInheritance);
        session.Events.StartStream<RoleAssignment>(created.RoleAssignmentId, created);

        return new CreateAssignmentResponse(created.RoleAssignmentId);
    }
}

public record CreateAssignmentRequest(Guid[] UserIds, bool AllowInheritance);

public record CreateAssignmentResponse(Guid Id);
