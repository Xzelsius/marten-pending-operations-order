namespace Repro.Api.Domain;

using System.Text.Json;
using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Weasel.Core;
using Weasel.Postgresql.Tables;

public sealed class RoleAssignmentSecurityQueryProjection : EventProjection
{
    private readonly DbObjectName tableIdentifier;

    public RoleAssignmentSecurityQueryProjection()
    {
        ProjectionName = "RoleAssignmentSecurityQueryProjection";

        var table = new Table(TableName);

        table.AddColumn<Guid>("id").AsPrimaryKey();
        table.AddColumn<Guid>("role_assignment_id");
        table.AddColumn<Guid>("user_id");
        table.AddColumn<Guid>("organizational_unit_id");
        table.AddColumn<string>("organizational_unit_path");
        table.AddColumn<string>("action");
        table.AddColumn<string>("permission");

        SchemaObjects.Add(table);
        tableIdentifier = table.Identifier;

        Options.DeleteDataInTableOnTeardown(table.Identifier);
    }

    public static string TableName => "mt_tbl_role_assignment_security";

    public void Project(IEvent<RoleAssignmentCreated> e, IDocumentOperations ops)
    {
        CreatePermissions(ops, e.Data.RoleAssignmentId, e.Data.RoleIds, e.Data.GroupIds, e.Data.UserIds, e.Data.OrganizationalUnitId, e.Data.AllowInheritance);
    }

    public void Project(IEvent<RoleAssignmentUpdated> e, IDocumentOperations ops)
    {
        DeletePermissions(ops, e.Data.RoleAssignmentId);
        CreatePermissions(ops, e.Data.RoleAssignmentId, e.Data.RoleIds, e.Data.GroupIds, e.Data.UserIds, e.Data.OrganizationalUnitId, e.Data.AllowInheritance);
    }

    public void Project(IEvent<RoleAssignmentDeleted> e, IDocumentOperations ops)
    {
        DeletePermissions(ops, e.Data.RoleAssignmentId);
    }

    private static List<Guid> CreateUserIdList(IDocumentOperations ops, IEnumerable<Guid> groupIds, IEnumerable<Guid> userIds)
    {
        var allUsersIds = new List<Guid>();

        // Add all the users that are directly assigned to the role.
        foreach (var userId in userIds)
        {
            allUsersIds.Add(userId);
        }

        // Add all the users that are assigned to the role through a group membership.
        foreach (var groupId in groupIds)
        {
            // snip, irrelevant for reproduction
        }

        // Remove all duplicate user ids.
        return allUsersIds.Distinct().ToList();
    }

    private void InsertPermissions(IDocumentOperations ops, Guid roleAssignmentId, List<Guid> userIds, Guid organizationalUnitId, string organizationalUnitPath, IEnumerable<ResourcePermission> permissions)
    {
        foreach (var userId in userIds)
        {
            foreach (var permission in permissions)
            {
                foreach (var action in permission.Actions)
                {
                    ops.QueueSqlCommand(
                        $"""
                         insert into {tableIdentifier} (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
                         values (?, ?, ?, ?, ?, ?, ?)
                         """,
                        Guid.NewGuid(),
                        roleAssignmentId,
                        userId,
                        organizationalUnitId,
                        organizationalUnitPath,
                        action,
                        JsonSerializer.Serialize(permission));
                }
            }
        }
    }

    private void InsertChildPermissions(IDocumentOperations ops, Guid roleAssignmentId, List<Guid> userIds, Guid parentId, string parentPath, IEnumerable<ResourcePermission> permissions)
    {
        // Note: Work in progress. We need to add the child permissions to the role assignment as well.
        var childOuIds = RelatedDataProvider.GetChildOus(parentId);
        foreach (var childOuId in childOuIds)
        {
            var childOuPath = $"{parentPath}/{childOuId}";
            InsertPermissions(ops, roleAssignmentId, userIds, childOuId, childOuPath, permissions);
            InsertChildPermissions(ops, roleAssignmentId, userIds, childOuId, childOuPath, permissions);
        }
    }

    private void CreatePermissions(
        IDocumentOperations ops,
        Guid roleAssignmentId,
        IEnumerable<Guid> roleIds,
        IEnumerable<Guid> groupIds,
        IEnumerable<Guid> userIds,
        Guid organizationalUnitId,
        bool allowInheritance)
    {
        var ouPath = RelatedDataProvider.GetOuPath(organizationalUnitId) ?? string.Empty;

        foreach (var roleId in roleIds)
        {
            // Create a list of all users that are assigned to the role. (Directly or through a group membership)
            var userIdList = CreateUserIdList(ops, groupIds, userIds);

            // Lookup the role with the permission.
            var role = RelatedDataProvider.GetRole(roleId);
            if (role is not null)
            {
                InsertPermissions(ops, roleAssignmentId, userIdList, organizationalUnitId, ouPath, role.Permissions);

                if (allowInheritance)
                {
                    InsertChildPermissions(ops, roleAssignmentId, userIdList, organizationalUnitId, ouPath, role.Permissions);
                }
            }
        }
    }

    private void DeletePermissions(IDocumentOperations ops, Guid roleAssignmentId)
    {
        ops.QueueSqlCommand($"delete from {tableIdentifier} where role_assignment_id = ?", roleAssignmentId);
    }
}
