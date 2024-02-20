namespace Repro.Api.Domain;

using Marten;
using Marten.Events;
using Marten.Events.Projections;
using Weasel.Core;
using Weasel.Postgresql.Tables;

public sealed class RoleAssignmentQueryProjection : EventProjection
{
    private readonly DbObjectName roleAssignmentTableIdentifier;
    private readonly DbObjectName userTableIdenfitier;
    private readonly DbObjectName groupTableIdenfitier;
    private readonly DbObjectName roleTableIdenfitier;
    private readonly ILogger<RoleAssignmentQueryProjection> logger;

    public RoleAssignmentQueryProjection(ILogger<RoleAssignmentQueryProjection> logger)
    {
        ProjectionName = "RoleAssignmentQueryProjection";

        var roleAssignmentTable = new Table(RoleAssignmentTableName);

        roleAssignmentTable.AddColumn<Guid>("id").AsPrimaryKey();
        roleAssignmentTable.AddColumn<Guid>("organizational_unit_id");
        roleAssignmentTable.AddColumn<bool>("allow_inheritance");

        SchemaObjects.Add(roleAssignmentTable);
        roleAssignmentTableIdentifier = roleAssignmentTable.Identifier;

        var userTable = new Table(UserTableName);

        userTable.AddColumn<Guid>("role_assignment_id").AsPrimaryKey();
        userTable.AddColumn<Guid>("user_id").AsPrimaryKey();

        SchemaObjects.Add(userTable);
        userTableIdenfitier = userTable.Identifier;

        var groupTable = new Table(GroupTableName);

        groupTable.AddColumn<Guid>("role_assignment_id").AsPrimaryKey();
        groupTable.AddColumn<Guid>("group_id").AsPrimaryKey();

        SchemaObjects.Add(groupTable);
        groupTableIdenfitier = groupTable.Identifier;

        var roleTable = new Table(RoleTableName);

        roleTable.AddColumn<Guid>("role_assignment_id").AsPrimaryKey();
        roleTable.AddColumn<Guid>("role_id").AsPrimaryKey();

        SchemaObjects.Add(roleTable);
        roleTableIdenfitier = roleTable.Identifier;

        foreach (var table in SchemaObjects.OfType<Table>())
        {
            Options.DeleteDataInTableOnTeardown(table.Identifier);
        }

        this.logger = logger;
    }

    public static string RoleAssignmentTableName => "mt_tbl_role_assignment";

    public static string UserTableName => $"{RoleAssignmentTableName}_user";

    public static string GroupTableName => $"{RoleAssignmentTableName}_group";

    public static string RoleTableName => $"{RoleAssignmentTableName}_role";

    public void Project(IEvent<RoleAssignmentCreated> e, IDocumentOperations ops)
    {
        logger.LogInformation("Project<RoleAssignmentCreated>()");

        ops.QueueSqlCommand(
            $"""
            insert into {roleAssignmentTableIdentifier} (id, organizational_unit_id, allow_inheritance)
            values (?, ?, ?)
            """,
            e.Data.RoleAssignmentId,
            e.Data.OrganizationalUnitId,
            e.Data.AllowInheritance
            );

        InsertUsers(e.Data.UserIds, e.Data.RoleAssignmentId, ops);
        InsertGroups(e.Data.GroupIds, e.Data.RoleAssignmentId, ops);
        InsertRoles(e.Data.RoleIds, e.Data.RoleAssignmentId, ops);
    }

    public void Project(IEvent<RoleAssignmentUpdated> e, IDocumentOperations ops)
    {
        logger.LogInformation("Project<RoleAssignmentUpdated>()");

        ops.QueueSqlCommand(
            $"""
            update {roleAssignmentTableIdentifier} SET
                organizational_unit_id = ?,
                allow_inheritance = ?
            where id = ?
            """,
            e.Data.OrganizationalUnitId,
            e.Data.AllowInheritance,
            e.Data.RoleAssignmentId);

        DeleteUsers(e.Data.RoleAssignmentId, ops);
        InsertUsers(e.Data.UserIds, e.Data.RoleAssignmentId, ops);

        DeleteGroups(e.Data.RoleAssignmentId, ops);
        InsertGroups(e.Data.GroupIds, e.Data.RoleAssignmentId, ops);

        DeleteRoles(e.Data.RoleAssignmentId, ops);
        InsertRoles(e.Data.RoleIds, e.Data.RoleAssignmentId, ops);
    }

    public void Project(IEvent<RoleAssignmentDeleted> e, IDocumentOperations ops)
    {
        logger.LogInformation("Project<RoleAssignmentDeleted>()");

        ops.QueueSqlCommand(
            $"""
            delete from {roleAssignmentTableIdentifier} where id = ?
            """,
            e.Data.RoleAssignmentId);
    }

    private void InsertUsers(IEnumerable<Guid> userIds, Guid roleAssignmentId, IDocumentOperations ops)
    {
        logger.LogInformation($"InsertUsers() for {roleAssignmentId} and {userIds.Count()} user(s)");

        foreach (var userId in userIds)
        {
            ops.QueueSqlCommand(
                $"""
                insert into {userTableIdenfitier} (role_assignment_id, user_id)
                values (?, ?)
                """,
                roleAssignmentId,
                userId);
        }
    }

    private void DeleteUsers(Guid roleAssignmentId, IDocumentOperations ops)
    {
        logger.LogInformation($"DeleteUsers() for {roleAssignmentId}");

        ops.QueueSqlCommand(
            $"""
            delete from {userTableIdenfitier} where role_assignment_id = ?
            """,
            roleAssignmentId);
    }

    private void InsertGroups(IEnumerable<Guid> groupIds, Guid roleAssignmentId, IDocumentOperations ops)
    {
        logger.LogInformation($"InsertGroups() for {roleAssignmentId} and {groupIds.Count()} group(s)");

        foreach (var groupId in groupIds)
        {
            ops.QueueSqlCommand(
                $"""
                insert into {groupTableIdenfitier} (role_assignment_id, group_id)
                values (?, ?)
                """,
                roleAssignmentId,
                groupId);
        }
    }

    private void DeleteGroups(Guid roleAssignmentId, IDocumentOperations ops)
    {
        logger.LogInformation($"DeleteGroups() for {roleAssignmentId}");

        ops.QueueSqlCommand(
            $"""
            delete from {groupTableIdenfitier} where role_assignment_id = ?
            """,
            roleAssignmentId);
    }

    private void InsertRoles(IEnumerable<Guid> roleIds, Guid roleAssignmentId, IDocumentOperations ops)
    {
        logger.LogInformation($"InsertRoles() for {roleAssignmentId} and {roleIds.Count()} role(s)");

        foreach (var roleId in roleIds)
        {
            ops.QueueSqlCommand(
                $"""
                insert into {roleTableIdenfitier} (role_assignment_id, role_id)
                values (?, ?)
                """,
                roleAssignmentId,
                roleId);
        }
    }

    private void DeleteRoles(Guid roleAssignmentId, IDocumentOperations ops)
    {
        logger.LogInformation($"DeleteRoles() for {roleAssignmentId}");

        ops.QueueSqlCommand(
            $"""
            delete from {roleTableIdenfitier} where role_assignment_id = ?
            """,
            roleAssignmentId);
    }
}
