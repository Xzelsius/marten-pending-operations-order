using SqlKata;

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

    public RoleAssignmentQueryProjection()
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
    }

    public static string RoleAssignmentTableName => "mt_tbl_role_assignment";

    public static string UserTableName => $"{RoleAssignmentTableName}_user";

    public static string GroupTableName => $"{RoleAssignmentTableName}_group";

    public static string RoleTableName => $"{RoleAssignmentTableName}_role";

    public void Project(IEvent<RoleAssignmentCreated> e, IDocumentOperations ops)
    {
        ops.QueueStatement(
            roleAssignmentTableIdentifier,
            statement => statement
                .AsInsert(new
                {
                    id = e.Data.RoleAssignmentId,
                    organizational_unit_id = e.Data.OrganizationalUnitId,
                    allow_inheritance = e.Data.AllowInheritance,
                }));

        InsertUsers(e.Data.UserIds, e.Data.RoleAssignmentId, false, ops);
        InsertGroups(e.Data.GroupIds, e.Data.RoleAssignmentId, false, ops);
        InsertRoles(e.Data.RoleIds, e.Data.RoleAssignmentId, false, ops);
    }

    public void Project(IEvent<RoleAssignmentUpdated> e, IDocumentOperations ops)
    {
        ops.QueueStatement(
            roleAssignmentTableIdentifier,
            statement => statement
                .AsUpdate(new
                {
                    organizational_unit_id = e.Data.OrganizationalUnitId,
                    allow_inheritance = e.Data.AllowInheritance,
                })
                .Where(new { id = e.Data.RoleAssignmentId, }));

        InsertUsers(e.Data.UserIds, e.Data.RoleAssignmentId, true, ops);
        InsertGroups(e.Data.GroupIds, e.Data.RoleAssignmentId, true, ops);
        InsertRoles(e.Data.RoleIds, e.Data.RoleAssignmentId, true,ops);
    }

    public void Project(IEvent<RoleAssignmentDeleted> e, IDocumentOperations ops)
    {
        ops.QueueStatement(
            roleAssignmentTableIdentifier,
            statement => statement
                .AsDelete()
                .Where(new { id = e.Data.RoleAssignmentId }));
    }

    private void InsertUsers(IEnumerable<Guid> userIds, Guid roleAssignmentId, bool clearExisting, IDocumentOperations ops)
    {
        var statements = new List<Action<Query>>();

        if (clearExisting)
        {
            statements.Add(statement => statement.AsDelete().Where(new { role_assignment_id = roleAssignmentId }));
        }

        statements.AddRange(userIds.Select(InsertUser));

        ops.QueueCombinedStatements(userTableIdenfitier.ToString(), statements.ToArray());

        Action<Query> InsertUser(Guid userId)
        {
            return statement => statement.AsInsert(new
            {
                role_assignment_id = roleAssignmentId,
                user_id = userId,
            });
        }
    }

    private void InsertGroups(IEnumerable<Guid> groupIds, Guid roleAssignmentId, bool clearExisting, IDocumentOperations ops)
    {
        var statements = new List<Action<Query>>();

        if (clearExisting)
        {
            statements.Add(statement => statement.AsDelete().Where(new { role_assignment_id = roleAssignmentId }));
        }

        statements.AddRange(groupIds.Select(InsertGroup));

        ops.QueueCombinedStatements(groupTableIdenfitier.ToString(), statements.ToArray());

        Action<Query> InsertGroup(Guid groupId)
        {
            return statement => statement.AsInsert(new
            {
                role_assignment_id = roleAssignmentId,
                group_id = groupId,
            });
        }
    }

    private void InsertRoles(IEnumerable<Guid> roleIds, Guid roleAssignmentId, bool clearExisting, IDocumentOperations ops)
    {
        var statements = new List<Action<Query>>();

        if (clearExisting)
        {
            statements.Add(statement => statement.AsDelete().Where(new { role_assignment_id = roleAssignmentId }));
        }

        statements.AddRange(roleIds.Select(InsertRole));

        ops.QueueCombinedStatements(roleTableIdenfitier.ToString(), statements.ToArray());

        Action<Query> InsertRole(Guid roleId)
        {
            return statement => statement.AsInsert(new
            {
                role_assignment_id = roleAssignmentId,
                role_id = roleId,
            });
        }
    }
}
