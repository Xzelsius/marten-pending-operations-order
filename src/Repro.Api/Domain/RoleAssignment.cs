namespace Repro.Api.Domain;

using JasperFx.Core;

public class RoleAssignment
{
    public Guid Id { get; set; }

    public long Version { get; set; }

    public Guid OrganizationalUnitId { get; set; }

    public IList<Guid> UserIds { get; init; } = [];

    public IList<Guid> GroupIds { get; init; } = [];

    public IList<Guid> RoleIds { get; init; } = [];

    public bool AllowInheritance { get; set; }

    public static RoleAssignment Create(RoleAssignmentCreated created)
    {
        return new RoleAssignment
        {
            Id = created.RoleAssignmentId,
            OrganizationalUnitId = created.OrganizationalUnitId,
            UserIds = created.UserIds.ToList(),
            GroupIds = created.GroupIds.ToList(),
            RoleIds = created.RoleIds.ToList(),
            AllowInheritance = created.AllowInheritance,
        };
    }

    public void Apply(RoleAssignmentUpdated @event)
    {
        Id = @event.RoleAssignmentId;
        OrganizationalUnitId = @event.OrganizationalUnitId;

        UserIds.Clear();
        UserIds.AddRange(@event.UserIds);

        GroupIds.Clear();
        GroupIds.AddRange(@event.GroupIds);

        RoleIds.Clear();
        RoleIds.AddRange(@event.RoleIds);

        AllowInheritance = @event.AllowInheritance;
    }
}

public interface IRoleAssignmentEvent
{
    Guid RoleAssignmentId { get; }
}
public record RoleAssignmentCreated(Guid RoleAssignmentId, Guid OrganizationalUnitId, IEnumerable<Guid> UserIds, IEnumerable<Guid> GroupIds, IEnumerable<Guid> RoleIds, bool AllowInheritance) : IRoleAssignmentEvent;
public record RoleAssignmentUpdated(Guid RoleAssignmentId, Guid OrganizationalUnitId, IEnumerable<Guid> UserIds, IEnumerable<Guid> GroupIds, IEnumerable<Guid> RoleIds, bool AllowInheritance) : IRoleAssignmentEvent;
public record RoleAssignmentDeleted(Guid RoleAssignmentId) : IRoleAssignmentEvent;
