namespace Repro.Api.Domain;

public static class RelatedDataProvider
{
    public static readonly Guid RoleId = Guid.Parse("ba9dea83-87d7-4ec5-bcc3-70436f1a14d1");

    public static readonly Guid RootOu = Guid.Parse("31b06cdc-eef4-4014-b97f-42a664e534b2");
    private static readonly Guid ChildOu1 = Guid.Parse("a0b684d5-cea8-408d-99a9-48d6cee22df5");
    private static readonly Guid ChildOu2 = Guid.Parse("1873d9be-9329-4f53-b9f7-66adfdaee38c");
    private static readonly Guid ChildOu3 = Guid.Parse("7a7eed61-8f98-413d-9b55-2bcb52b8adda");
    private static readonly OrganizationalUnit[] AvailableOrganizationalUnits =
    [
        new(RootOu, null, $"{RootOu}"),
        new(ChildOu1, RootOu, $"{RootOu}/{ChildOu1}"),
        new(ChildOu2, ChildOu1, $"{RootOu}/{ChildOu1}/{ChildOu2}"),
        new(ChildOu3, ChildOu2, $"{RootOu}/{ChildOu1}/{ChildOu2}/{ChildOu3}"),
    ];

    public static Role? GetRole(Guid id)
    {
        if (id == RoleId)
        {
            return new Role
            {
                Id = RoleId,
                Permissions = new List<ResourcePermission>
                {
                    new()
                    {
                        Actions = new List<string>
                        {
                            "TenantConfiguration.*"
                        },
                    }
                }
            };
        }

        return null;
    }

    public static string? GetOuPath(Guid id)
    {
        return AvailableOrganizationalUnits.FirstOrDefault(x => x.Id == id)?.Path;
    }

    public static IList<Guid> GetChildOus(Guid parentId)
    {
        return AvailableOrganizationalUnits.Where(x => x.ParentId == parentId).Select(x => x.Id).ToList();
    }

    private record OrganizationalUnit(Guid Id, Guid? ParentId, string Path);
}

public sealed class Role
{
    public Guid Id { get; set; }

    public IList<ResourcePermission> Permissions { get; set; } = [];
}

public sealed class ResourcePermission
{
    public IList<string> Actions { get; init; } = new List<string>();
}
