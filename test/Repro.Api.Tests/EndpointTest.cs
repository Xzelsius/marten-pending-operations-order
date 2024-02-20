using Alba;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using Oakton;
using Repro.Api.Domain;
using Repro.Api.Endpoints;

namespace Repro.Api.Tests;

public sealed class EndpointTest
{
    public EndpointTest()
    {
        OaktonEnvironment.AutoStartHost = true;
    }

    [Fact]
    public async Task Create_and_Update_works()
    {
        using var host = await AlbaHost.For<Program>();
        await ResetDatabase(host);

        Guid[] userIds = [Guid.NewGuid()];

        var createWithOneUser = await host.Scenario(scenario =>
        {
            scenario
                .Post
                .Json(new CreateAssignmentRequest(userIds, true))
                .ToUrl("/create-assignment");
        });

        var roleAssignmentId = (await createWithOneUser.ReadAsJsonAsync<CreateAssignmentResponse>())!.Id;

        await AssertData(host, roleAssignmentId, userIds);

        userIds = [Guid.NewGuid()];

        await host.Scenario(scenario =>
        {
            scenario
                .Post
                .Json(new UpdateAssignmentRequest(userIds, true))
                .ToUrl($"/update-assignment/{roleAssignmentId}");

            scenario.StatusCodeShouldBe(204);
        });

        await AssertData(host, roleAssignmentId, userIds);

        userIds = [Guid.NewGuid(), Guid.NewGuid()];

        await host.Scenario(scenario =>
        {
            scenario
                .Post
                .Json(new UpdateAssignmentRequest(userIds, true))
                .ToUrl($"/update-assignment/{roleAssignmentId}");

            scenario.StatusCodeShouldBe(204);
        });

        await AssertData(host, roleAssignmentId, userIds);

        userIds = [Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()];

        await host.Scenario(scenario =>
        {
            scenario
                .Post
                .Json(new UpdateAssignmentRequest(userIds, true))
                .ToUrl($"/update-assignment/{roleAssignmentId}");

            scenario.StatusCodeShouldBe(204);
        });

        await AssertData(host, roleAssignmentId, userIds);
    }

    private static async Task AssertData(IAlbaHost host, Guid roleAssignmentId, Guid[] userIds)
    {
        var session = host.Services.GetRequiredService<IDocumentSession>();

        var roleAssignment = await session.LoadAsync<RoleAssignment>(roleAssignmentId);

        roleAssignment.Should().NotBeNull();
        roleAssignment!.AllowInheritance.Should().BeTrue();
        roleAssignment.UserIds.Should().BeEquivalentTo(userIds);

        var assignedUsers = await session.QueryAsync<Guid>("select user_id from mt_tbl_role_assignment_user where role_assignment_id = ?", roleAssignmentId);
        assignedUsers.Should().BeEquivalentTo(userIds);

        var usersWithPermission = await session.QueryAsync<Guid>("select user_id from mt_tbl_role_assignment_security where role_assignment_id = ?", roleAssignmentId);
        var grouped = usersWithPermission.GroupBy(x => x).ToList();

        foreach (var userId in userIds)
        {
            var group = grouped.SingleOrDefault(x => x.Key == userId);

            group.Should().NotBeNull();
            group.Should().HaveCount(4, "we have 4 organizational units and inheritance enabled");
        }
    }

    private static async Task ResetDatabase(IAlbaHost host)
    {
        var store = host.Services.GetRequiredService<IDocumentStore>();
        var db = store.Storage.Database;

        await db.DeleteAllEventDataAsync();
        await db.DeleteAllDocumentsAsync();
        await db.ApplyAllConfiguredChangesToDatabaseAsync();        
    }

    private class SecurityProjectionResult
    {
        public Guid User_Id { get; set; }
    }    
}
