namespace Repro.Api.Endpoints;

using Marten;
using Repro.Api.Domain;
using Wolverine.Http;

public static class CreateAssignmentEndpoint
{
    [WolverinePost("/create-assignment")]
    public static Guid Create(CreateAssignmentRequest request, IDocumentSession session)
    {
        Guid ouId = RelatedDataProvider.RootOu;

        Guid[] userIds = Enumerable
            .Range(1, request.AmountOfUsers)
            .Select(x => Guid.NewGuid())
            .ToArray();

        Guid[] groupIds = [];

        Guid[] roleIds = [RelatedDataProvider.RoleId];

        var created = new RoleAssignmentCreated(Guid.NewGuid(), ouId, userIds, groupIds, roleIds, request.AllowInheritance);
        session.Events.StartStream<RoleAssignment>(created.RoleAssignmentId, created);

        return created.RoleAssignmentId;
    }
}

public record CreateAssignmentRequest(int AmountOfUsers, bool AllowInheritance);
