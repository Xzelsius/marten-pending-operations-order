# Test Results #1

## 1. Create RoleAssignment with 1 User and Inheritance

```
curl -X 'POST' \
  'http://localhost:5255/create-assignment' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{
  "amountOfUsers": 1,
  "allowInheritance": true
}'
```

responds with

```
"cf42839b-20b8-4112-934f-c2aba75d5b9c"
```

and has the following log

```
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      Project<RoleAssignmentCreated>()
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertUsers() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 1 user(s)
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertGroups() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 0 group(s)
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertRoles() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 1 role(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      Project<RoleAssignmentCreated>()
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreatePermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreateUserIdList()
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreateUserIdList() resulted in 1 user ids
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2 with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2 with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5 with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5 with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda with 1 user(s)
info: Wolverine.Runtime.WolverineRuntime[107]
      No routes can be determined for Envelope #018dc56a-6842-426e-9ce0-125700fcf2a9 (RoleAssignmentCreated)
dbug: Marten.IDocumentStore[0]
      Marten executed in 5 ms, SQL: select public.mt_upsert_roleassignment(:p0, :p1, :p2, :p3);insert into public.mt_tbl_role_assignment (id, organizational_unit_id, allow_inheritance)
      values (:p4, :p5, :p6);insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p7, :p8);insert into public.mt_tbl_role_assignment_role (role_assignment_id, role_id)
      values (:p9, :p10);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p11, :p12, :p13, :p14, :p15, :p16, :p17);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p18, :p19, :p20, :p21, :p22, :p23, :p24);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p25, :p26, :p27, :p28, :p29, :p30, :p31);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p32, :p33, :p34, :p35, :p36, :p37, :p38);insert into public.mt_streams (id, type, version, tenant_id) values (:p39, :p40, :p41, :p42);insert into public.mt_events (data, type, mt_dotnet_type, seq_id, id, stream_id, version, timestamp, tenant_id) values (:p43, :p44, :p45, :p46, :p47, :p48, :p49, :p50, :p51);
  p0: {"Id":"cf42839b-20b8-4112-934f-c2aba75d5b9c","Version":1,"OrganizationalUnitId":"31b06cdc-eef4-4014-b97f-42a664e534b2","UserIds":["0a189401-ff74-41a7-a652-985286e25b27"],"GroupIds":[],"RoleIds":["ba9dea83-87d7-4ec5-bcc3-70436f1a14d1"],"AllowInheritance":true}
        p1: Repro.Api.Domain.RoleAssignment
        p2: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p3: 018dc56a-681d-4f7e-8500-2610a5e51355
        p4: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p5: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p6: True
        p7: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p8: 0a189401-ff74-41a7-a652-985286e25b27
        p9: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p10: ba9dea83-87d7-4ec5-bcc3-70436f1a14d1
        p11: ee0cdff1-0e75-4f66-b78d-79b2e7a2c3d1
        p12: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p13: 0a189401-ff74-41a7-a652-985286e25b27
        p14: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p15: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p16: TenantConfiguration.*
        p17: {"Actions":["TenantConfiguration.*"]}
        p18: 2b53673e-4fb8-47d3-82f9-18df297ac92e
        p19: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p20: 0a189401-ff74-41a7-a652-985286e25b27
        p21: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p22: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p23: TenantConfiguration.*
        p24: {"Actions":["TenantConfiguration.*"]}
        p25: d251c142-f659-43f2-afbd-47d51ea0da7d
        p26: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p27: 0a189401-ff74-41a7-a652-985286e25b27
        p28: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p29: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p30: TenantConfiguration.*
        p31: {"Actions":["TenantConfiguration.*"]}
        p32: 21aa3fe0-6b8e-4f1a-a0b3-231f06ab4746
        p33: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p34: 0a189401-ff74-41a7-a652-985286e25b27
        p35: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p36: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p37: TenantConfiguration.*
        p38: {"Actions":["TenantConfiguration.*"]}
        p39: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p40: role_assignment
        p41: 1
        p42: *DEFAULT*
        p43: {"RoleAssignmentId":"cf42839b-20b8-4112-934f-c2aba75d5b9c","OrganizationalUnitId":"31b06cdc-eef4-4014-b97f-42a664e534b2","UserIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":["0a189401-ff74-41a7-a652-985286e25b27"]},"GroupIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":[]},"RoleIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":["ba9dea83-87d7-4ec5-bcc3-70436f1a14d1"]},"AllowInheritance":true}
        p44: role_assignment_created
        p45: Repro.Api.Domain.RoleAssignmentCreated, Repro.Api
        p46: 1
        p47: 018dc56a-653d-4576-98d6-494334c402e5
        p48: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p49: 1
        p50: 20/02/2024 07:28:20 +00:00
        p51: *DEFAULT*
dbug: Marten.IDocumentStore[0]
      Persisted 1 updates in 5 ms, 0 inserts, and 0 deletions
```

## 2. Update RoleAssignment with 1 User and Inheritance

```
curl -X 'POST' \
  'http://localhost:5255/update-assignment/cf42839b-20b8-4112-934f-c2aba75d5b9c' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "amountOfUsers": 1,
  "allowInheritance": true
}'
```

responds with HTTP 204

and has the following log

```
dbug: Marten.IDocumentStore[0]
      Marten executed in 1 ms, SQL: select nextval('public.mt_events_sequence') from generate_series(1,1)

dbug: Marten.IDocumentStore[0]
      Marten executed in 0 ms, SQL: select id, version, type, timestamp, created as timestamp, is_archived from public.mt_streams where id = :p0
  p0: cf42839b-20b8-4112-934f-c2aba75d5b9c
dbug: Marten.IDocumentStore[0]
      Marten executed in 1 ms, SQL: select d.id, d.data from public.mt_doc_roleassignment as d where id = :id
  id: cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      Project<RoleAssignmentUpdated>()
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteUsers() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertUsers() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 1 user(s)
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteGroups() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertGroups() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 0 group(s)
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteRoles() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertRoles() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 1 role(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      Project<RoleAssignmentUpdated>()
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      DeletePermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreatePermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreateUserIdList()
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreateUserIdList() resulted in 1 user ids
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2 with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2 with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5 with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5 with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda with 1 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda with 1 user(s)
info: Wolverine.Runtime.WolverineRuntime[107]
      No routes can be determined for Envelope #018dc56c-c09d-4aa2-ab3e-911ed3d93300 (RoleAssignmentUpdated)
dbug: Marten.IDocumentStore[0]
      Marten executed in 2 ms, SQL: select public.mt_upsert_roleassignment(:p0, :p1, :p2, :p3);update public.mt_tbl_role_assignment SET
          organizational_unit_id = :p4,
          allow_inheritance = :p5
      where id = :p6;delete from public.mt_tbl_role_assignment_user where role_assignment_id = :p7;insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p8, :p9);delete from public.mt_tbl_role_assignment_group where role_assignment_id = :p10;delete from public.mt_tbl_role_assignment_role where role_assignment_id = :p11;insert into public.mt_tbl_role_assignment_role (role_assignment_id, role_id)
      values (:p12, :p13);delete from public.mt_tbl_role_assignment_security where role_assignment_id = :p14;insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p15, :p16, :p17, :p18, :p19, :p20, :p21);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p22, :p23, :p24, :p25, :p26, :p27, :p28);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p29, :p30, :p31, :p32, :p33, :p34, :p35);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p36, :p37, :p38, :p39, :p40, :p41, :p42);update public.mt_streams set version = :p43 where id = :p44 and version = :p45;insert into public.mt_events (data, type, mt_dotnet_type, seq_id, id, stream_id, version, timestamp, tenant_id) values (:p46, :p47, :p48, :p49, :p50, :p51, :p52, :p53, :p54);
  p0: {"Id":"cf42839b-20b8-4112-934f-c2aba75d5b9c","Version":2,"OrganizationalUnitId":"31b06cdc-eef4-4014-b97f-42a664e534b2","UserIds":["ba39969b-d993-4aac-a3ae-6c8b2e006c91"],"GroupIds":[],"RoleIds":["ba9dea83-87d7-4ec5-bcc3-70436f1a14d1"],"AllowInheritance":true}
        p1: Repro.Api.Domain.RoleAssignment
        p2: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p3: 018dc56c-c07d-48ae-9f0c-436a95b64513
        p4: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p5: True
        p6: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p7: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p8: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p9: ba39969b-d993-4aac-a3ae-6c8b2e006c91
        p10: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p11: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p12: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p13: ba9dea83-87d7-4ec5-bcc3-70436f1a14d1
        p14: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p15: 0e594a09-acc0-4ac4-838a-e4fa0a5e9b12
        p16: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p17: ba39969b-d993-4aac-a3ae-6c8b2e006c91
        p18: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p19: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p20: TenantConfiguration.*
        p21: {"Actions":["TenantConfiguration.*"]}
        p22: 46139ebf-8e4a-46f6-8d55-c9990756e392
        p23: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p24: ba39969b-d993-4aac-a3ae-6c8b2e006c91
        p25: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p26: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p27: TenantConfiguration.*
        p28: {"Actions":["TenantConfiguration.*"]}
        p29: 4cd9a4c3-3558-4c0e-adb2-716fa053d559
        p30: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p31: ba39969b-d993-4aac-a3ae-6c8b2e006c91
        p32: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p33: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p34: TenantConfiguration.*
        p35: {"Actions":["TenantConfiguration.*"]}
        p36: f1264fe5-316e-4611-8c7d-2ddf595ab4fd
        p37: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p38: ba39969b-d993-4aac-a3ae-6c8b2e006c91
        p39: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p40: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p41: TenantConfiguration.*
        p42: {"Actions":["TenantConfiguration.*"]}
        p43: 2
        p44: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p45: 1
        p46: {"RoleAssignmentId":"cf42839b-20b8-4112-934f-c2aba75d5b9c","OrganizationalUnitId":"31b06cdc-eef4-4014-b97f-42a664e534b2","UserIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":["ba39969b-d993-4aac-a3ae-6c8b2e006c91"]},"GroupIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":[]},"RoleIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":["ba9dea83-87d7-4ec5-bcc3-70436f1a14d1"]},"AllowInheritance":true}
        p47: role_assignment_updated
        p48: Repro.Api.Domain.RoleAssignmentUpdated, Repro.Api
        p49: 2
        p50: 018dc56c-c05a-46ca-ae53-a45e2898fbb3
        p51: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p52: 2
        p53: 20/02/2024 07:30:55 +00:00
        p54: *DEFAULT*
dbug: Marten.IDocumentStore[0]
      Persisted 1 updates in 2 ms, 0 inserts, and 0 deletions
```

## 3. Update RoleAssignment with 2 User and Inheritance

```
curl -X 'POST' \
  'http://localhost:5255/update-assignment/cf42839b-20b8-4112-934f-c2aba75d5b9c' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "amountOfUsers": 2,
  "allowInheritance": true
}'
```

responds with HTTP 204

and has the following log

```
dbug: Marten.IDocumentStore[0]
      Marten executed in 1 ms, SQL: select nextval('public.mt_events_sequence') from generate_series(1,1)

dbug: Marten.IDocumentStore[0]
      Marten executed in 1 ms, SQL: select id, version, type, timestamp, created as timestamp, is_archived from public.mt_streams where id = :p0
  p0: cf42839b-20b8-4112-934f-c2aba75d5b9c
dbug: Marten.IDocumentStore[0]
      Marten executed in 0 ms, SQL: select d.id, d.data from public.mt_doc_roleassignment as d where id = :id
  id: cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      Project<RoleAssignmentUpdated>()
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteUsers() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertUsers() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 2 user(s)
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteGroups() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertGroups() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 0 group(s)
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteRoles() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertRoles() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 1 role(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      Project<RoleAssignmentUpdated>()
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      DeletePermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreatePermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreateUserIdList()
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreateUserIdList() resulted in 2 user ids
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2 with 2 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2 with 2 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5 with 2 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5 with 2 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c with 2 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c with 2 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda with 2 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda with 2 user(s)
info: Wolverine.Runtime.WolverineRuntime[107]
      No routes can be determined for Envelope #018dc56e-a631-4d3b-a07b-3057b99e7ba0 (RoleAssignmentUpdated)
dbug: Marten.IDocumentStore[0]
      Marten executed in 1 ms, SQL: select public.mt_upsert_roleassignment(:p0, :p1, :p2, :p3);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p4, :p5, :p6, :p7, :p8, :p9, :p10);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p11, :p12, :p13, :p14, :p15, :p16, :p17);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p18, :p19, :p20, :p21, :p22, :p23, :p24);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p25, :p26, :p27, :p28, :p29, :p30, :p31);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p32, :p33, :p34, :p35, :p36, :p37, :p38);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p39, :p40, :p41, :p42, :p43, :p44, :p45);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p46, :p47, :p48, :p49, :p50, :p51, :p52);delete from public.mt_tbl_role_assignment_security where role_assignment_id = :p53;delete from public.mt_tbl_role_assignment_role where role_assignment_id = :p54;delete from public.mt_tbl_role_assignment_group where role_assignment_id = :p55;insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p56, :p57);insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p58, :p59);delete from public.mt_tbl_role_assignment_user where role_assignment_id = :p60;update public.mt_tbl_role_assignment SET
          organizational_unit_id = :p61,
          allow_inheritance = :p62
      where id = :p63;insert into public.mt_tbl_role_assignment_role (role_assignment_id, role_id)
      values (:p64, :p65);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p66, :p67, :p68, :p69, :p70, :p71, :p72);update public.mt_streams set version = :p73 where id = :p74 and version = :p75;insert into public.mt_events (data, type, mt_dotnet_type, seq_id, id, stream_id, version, timestamp, tenant_id) values (:p76, :p77, :p78, :p79, :p80, :p81, :p82, :p83, :p84);
  p0: {"Id":"cf42839b-20b8-4112-934f-c2aba75d5b9c","Version":3,"OrganizationalUnitId":"31b06cdc-eef4-4014-b97f-42a664e534b2","UserIds":["f0ff58aa-4c19-4005-bd26-efd83716421e","e9177aa7-193e-46b7-80d3-282e3f7a0de9"],"GroupIds":[],"RoleIds":["ba9dea83-87d7-4ec5-bcc3-70436f1a14d1"],"AllowInheritance":true}
        p1: Repro.Api.Domain.RoleAssignment
        p2: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p3: 018dc56e-a614-40e5-8b34-020d026de5c4
        p4: 9e424f09-4ac2-4af7-be42-04810317c14e
        p5: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p6: e9177aa7-193e-46b7-80d3-282e3f7a0de9
        p7: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p8: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p9: TenantConfiguration.*
        p10: {"Actions":["TenantConfiguration.*"]}
        p11: 419b98ad-06a7-4b87-8e1b-22eb544668f9
        p12: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p13: f0ff58aa-4c19-4005-bd26-efd83716421e
        p14: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p15: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p16: TenantConfiguration.*
        p17: {"Actions":["TenantConfiguration.*"]}
        p18: 635a2113-b355-4b5a-9279-951a17296af7
        p19: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p20: e9177aa7-193e-46b7-80d3-282e3f7a0de9
        p21: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p22: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p23: TenantConfiguration.*
        p24: {"Actions":["TenantConfiguration.*"]}
        p25: ee0a1eb9-89f4-4bcc-8080-a93d5fefa481
        p26: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p27: f0ff58aa-4c19-4005-bd26-efd83716421e
        p28: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p29: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p30: TenantConfiguration.*
        p31: {"Actions":["TenantConfiguration.*"]}
        p32: 46ce17c6-c151-468b-a086-6a9a90335690
        p33: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p34: e9177aa7-193e-46b7-80d3-282e3f7a0de9
        p35: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p36: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p37: TenantConfiguration.*
        p38: {"Actions":["TenantConfiguration.*"]}
        p39: e495a760-1a93-4b95-8022-2d80dde35425
        p40: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p41: f0ff58aa-4c19-4005-bd26-efd83716421e
        p42: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p43: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p44: TenantConfiguration.*
        p45: {"Actions":["TenantConfiguration.*"]}
        p46: 1b0109cb-4e7a-45a8-bfa7-22db728192bc
        p47: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p48: f0ff58aa-4c19-4005-bd26-efd83716421e
        p49: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p50: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p51: TenantConfiguration.*
        p52: {"Actions":["TenantConfiguration.*"]}
        p53: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p54: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p55: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p56: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p57: e9177aa7-193e-46b7-80d3-282e3f7a0de9
        p58: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p59: f0ff58aa-4c19-4005-bd26-efd83716421e
        p60: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p61: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p62: True
        p63: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p64: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p65: ba9dea83-87d7-4ec5-bcc3-70436f1a14d1
        p66: 02844a11-357d-4ee0-bc89-d9aeddc78661
        p67: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p68: e9177aa7-193e-46b7-80d3-282e3f7a0de9
        p69: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p70: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p71: TenantConfiguration.*
        p72: {"Actions":["TenantConfiguration.*"]}
        p73: 3
        p74: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p75: 2
        p76: {"RoleAssignmentId":"cf42839b-20b8-4112-934f-c2aba75d5b9c","OrganizationalUnitId":"31b06cdc-eef4-4014-b97f-42a664e534b2","UserIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":["f0ff58aa-4c19-4005-bd26-efd83716421e","e9177aa7-193e-46b7-80d3-282e3f7a0de9"]},"GroupIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":[]},"RoleIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":["ba9dea83-87d7-4ec5-bcc3-70436f1a14d1"]},"AllowInheritance":true}
        p77: role_assignment_updated
        p78: Repro.Api.Domain.RoleAssignmentUpdated, Repro.Api
        p79: 3
        p80: 018dc56e-a60b-4144-b744-ad4ece742a8a
        p81: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p82: 3
        p83: 20/02/2024 07:32:59 +00:00
        p84: *DEFAULT*
dbug: Marten.IDocumentStore[0]
      Persisted 1 updates in 1 ms, 0 inserts, and 0 deletions
```

## 4. Update RoleAssignment with 5 User and Inheritance

```
curl -X 'POST' \
  'http://localhost:5255/update-assignment/cf42839b-20b8-4112-934f-c2aba75d5b9c' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "amountOfUsers": 5,
  "allowInheritance": true
}'
```

responds with HTTP 500

```
Marten.Exceptions.MartenCommandException: Marten Command Failure:$
$
$
23505: duplicate key value violates unique constraint "pkey_mt_tbl_role_assignment_role_role_assignment_id_role_id"

DETAIL: Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
 ---> Npgsql.PostgresException (0x80004005): 23505: duplicate key value violates unique constraint "pkey_mt_tbl_role_assignment_role_role_assignment_id_role_id"

DETAIL: Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
   at Npgsql.Internal.NpgsqlConnector.<ReadMessage>g__ReadMessageLong|234_0(NpgsqlConnector connector, Boolean async, DataRowLoadingMode dataRowLoadingMode, Boolean readingNotifications, Boolean isReadingPrependedMessage)
   at Npgsql.NpgsqlDataReader.NextResult(Boolean async, Boolean isConsuming, CancellationToken cancellationToken)
   at Npgsql.NpgsqlDataReader.NextResult(Boolean async, Boolean isConsuming, CancellationToken cancellationToken)
   at Marten.Internal.UpdateBatch.ApplyCallbacksAsync(IReadOnlyList`1 operations, DbDataReader reader, IList`1 exceptions, CancellationToken token)
   at Marten.Internal.UpdateBatch.ApplyChangesAsync(IMartenSession session, CancellationToken token)
   at Marten.Internal.UpdateBatch.ApplyChangesAsync(IMartenSession session, CancellationToken token)
  Exception data:
    Severity: ERROR
    SqlState: 23505
    MessageText: duplicate key value violates unique constraint "pkey_mt_tbl_role_assignment_role_role_assignment_id_role_id"
    Detail: Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
    SchemaName: public
    TableName: mt_tbl_role_assignment_role
    ConstraintName: pkey_mt_tbl_role_assignment_role_role_assignment_id_role_id
    File: nbtinsert.c
    Line: 666
    Routine: _bt_check_unique
   --- End of inner exception stack trace ---
   at JasperFx.Core.Exceptions.ExceptionTransformExtensions.TransformAndThrow(IEnumerable`1 transforms, Exception ex)
   at Marten.Internal.UpdateBatch.ApplyChangesAsync(IMartenSession session, CancellationToken token)
   at Marten.Internal.Sessions.DocumentSessionBase.ExecuteBatchAsync(IUpdateBatch batch, CancellationToken token)
   at Marten.Internal.Sessions.DocumentSessionBase.ExecuteBatchAsync(IUpdateBatch batch, CancellationToken token)
   at Marten.Internal.Sessions.DocumentSessionBase.SaveChangesAsync(CancellationToken token)
   at Internal.Generated.WolverineHandlers.POST_update_assignment_id.Handle(HttpContext httpContext)
   at Internal.Generated.WolverineHandlers.POST_update_assignment_id.Handle(HttpContext httpContext)
   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)

HEADERS
=======
Accept: */*
Connection: keep-alive
Host: localhost:5255
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/121.0.0.0 Safari/537.36 Edg/121.0.0.0
Accept-Encoding: gzip, deflate, br
Accept-Language: en-US,en;q=0.9
Content-Type: application/json
Origin: http://localhost:5255
Referer: http://localhost:5255/swagger/index.html
Content-Length: 52
sec-ch-ua: "Not A(Brand";v="99", "Microsoft Edge";v="121", "Chromium";v="121"
DNT: 1
sec-ch-ua-mobile: ?0
sec-ch-ua-platform: "Windows"
Sec-Fetch-Site: same-origin
Sec-Fetch-Mode: cors
Sec-Fetch-Dest: empty
```

and has the following log

```
dbug: Marten.IDocumentStore[0]
      Marten executed in 1 ms, SQL: select nextval('public.mt_events_sequence') from generate_series(1,1)

dbug: Marten.IDocumentStore[0]
      Marten executed in 0 ms, SQL: select id, version, type, timestamp, created as timestamp, is_archived from public.mt_streams where id = :p0
  p0: cf42839b-20b8-4112-934f-c2aba75d5b9c
dbug: Marten.IDocumentStore[0]
      Marten executed in 1 ms, SQL: select d.id, d.data from public.mt_doc_roleassignment as d where id = :id
  id: cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      Project<RoleAssignmentUpdated>()
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteUsers() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertUsers() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 5 user(s)
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteGroups() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertGroups() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 0 group(s)
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      DeleteRoles() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentQueryProjection[0]
      InsertRoles() for cf42839b-20b8-4112-934f-c2aba75d5b9c and 1 role(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      Project<RoleAssignmentUpdated>()
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      DeletePermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreatePermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreateUserIdList()
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      CreateUserIdList() resulted in 5 user ids
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2 with 5 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2 with 5 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5 with 5 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5 with 5 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c with 5 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c with 5 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InserPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda with 5 user(s)
info: Repro.Api.Domain.RoleAssignmentSecurityQueryProjection[0]
      InsertChildPermissions() for cf42839b-20b8-4112-934f-c2aba75d5b9c and OU 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda with 5 user(s)
info: Wolverine.Runtime.WolverineRuntime[107]
      No routes can be determined for Envelope #018dc570-7f7a-4485-9308-f46639e98826 (RoleAssignmentUpdated)
dbug: Marten.IDocumentStore[0]
      Marten executed in 47 ms, SQL: select public.mt_upsert_roleassignment(:p0, :p1, :p2, :p3);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p4, :p5, :p6, :p7, :p8, :p9, :p10);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p11, :p12, :p13, :p14, :p15, :p16, :p17);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p18, :p19, :p20, :p21, :p22, :p23, :p24);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p25, :p26, :p27, :p28, :p29, :p30, :p31);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p32, :p33, :p34, :p35, :p36, :p37, :p38);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p39, :p40, :p41, :p42, :p43, :p44, :p45);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p46, :p47, :p48, :p49, :p50, :p51, :p52);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p53, :p54, :p55, :p56, :p57, :p58, :p59);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p60, :p61, :p62, :p63, :p64, :p65, :p66);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p67, :p68, :p69, :p70, :p71, :p72, :p73);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p74, :p75, :p76, :p77, :p78, :p79, :p80);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p81, :p82, :p83, :p84, :p85, :p86, :p87);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p88, :p89, :p90, :p91, :p92, :p93, :p94);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p95, :p96, :p97, :p98, :p99, :p100, :p101);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p102, :p103, :p104, :p105, :p106, :p107, :p108);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p109, :p110, :p111, :p112, :p113, :p114, :p115);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p116, :p117, :p118, :p119, :p120, :p121, :p122);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p123, :p124, :p125, :p126, :p127, :p128, :p129);delete from public.mt_tbl_role_assignment_security where role_assignment_id = :p130;insert into public.mt_tbl_role_assignment_role (role_assignment_id, role_id)
      values (:p131, :p132);delete from public.mt_tbl_role_assignment_role where role_assignment_id = :p133;delete from public.mt_tbl_role_assignment_group where role_assignment_id = :p134;insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p135, :p136);insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p137, :p138);insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p139, :p140);insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p141, :p142);insert into public.mt_tbl_role_assignment_user (role_assignment_id, user_id)
      values (:p143, :p144);delete from public.mt_tbl_role_assignment_user where role_assignment_id = :p145;update public.mt_tbl_role_assignment SET
          organizational_unit_id = :p146,
          allow_inheritance = :p147
      where id = :p148;insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p149, :p150, :p151, :p152, :p153, :p154, :p155);insert into public.mt_tbl_role_assignment_security (id, role_assignment_id, user_id, organizational_unit_id, organizational_unit_path, action, permission)
      values (:p156, :p157, :p158, :p159, :p160, :p161, :p162);update public.mt_streams set version = :p163 where id = :p164 and version = :p165;insert into public.mt_events (data, type, mt_dotnet_type, seq_id, id, stream_id, version, timestamp, tenant_id) values (:p166, :p167, :p168, :p169, :p170, :p171, :p172, :p173, :p174);
  p0: {"Id":"cf42839b-20b8-4112-934f-c2aba75d5b9c","Version":4,"OrganizationalUnitId":"31b06cdc-eef4-4014-b97f-42a664e534b2","UserIds":["ddffc31b-3bde-4a3a-8d4b-7aaac9ee68ed","05bb9654-487f-4440-94c5-832da07ddd87","82624226-d4d8-4f28-95c9-b6fd43cd6437","8780dd4e-9416-45c1-b118-8bc73971333a","20de13a8-4db9-4a77-9557-fc1353ee0488"],"GroupIds":[],"RoleIds":["ba9dea83-87d7-4ec5-bcc3-70436f1a14d1"],"AllowInheritance":true}
        p1: Repro.Api.Domain.RoleAssignment
        p2: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p3: 018dc570-7f5b-48cd-912e-8d5ba9d5fbb9
        p4: 0e8c076d-7e3b-4d64-93fe-46ae9f011750
        p5: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p6: 82624226-d4d8-4f28-95c9-b6fd43cd6437
        p7: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p8: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p9: TenantConfiguration.*
        p10: {"Actions":["TenantConfiguration.*"]}
        p11: 1d18e8a2-e584-4c4a-b5fa-f630445ee359
        p12: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p13: 05bb9654-487f-4440-94c5-832da07ddd87
        p14: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p15: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p16: TenantConfiguration.*
        p17: {"Actions":["TenantConfiguration.*"]}
        p18: d9a4a9c2-7e2e-4a90-944d-bf6c5ef65a85
        p19: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p20: ddffc31b-3bde-4a3a-8d4b-7aaac9ee68ed
        p21: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p22: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p23: TenantConfiguration.*
        p24: {"Actions":["TenantConfiguration.*"]}
        p25: c141d97c-e035-4fb6-826a-a6b9cf3f65d7
        p26: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p27: 20de13a8-4db9-4a77-9557-fc1353ee0488
        p28: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p29: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p30: TenantConfiguration.*
        p31: {"Actions":["TenantConfiguration.*"]}
        p32: 0a7b1228-55c4-4429-a87c-b341279c52c5
        p33: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p34: 8780dd4e-9416-45c1-b118-8bc73971333a
        p35: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p36: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p37: TenantConfiguration.*
        p38: {"Actions":["TenantConfiguration.*"]}
        p39: ec68b5a8-5c5c-4de0-a571-e4d266b70239
        p40: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p41: 82624226-d4d8-4f28-95c9-b6fd43cd6437
        p42: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p43: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p44: TenantConfiguration.*
        p45: {"Actions":["TenantConfiguration.*"]}
        p46: a494770a-57cf-43fc-94c4-bf27305f1190
        p47: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p48: 05bb9654-487f-4440-94c5-832da07ddd87
        p49: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p50: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p51: TenantConfiguration.*
        p52: {"Actions":["TenantConfiguration.*"]}
        p53: fc8c43ae-e32b-4432-916c-1e7b2710c5d6
        p54: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p55: ddffc31b-3bde-4a3a-8d4b-7aaac9ee68ed
        p56: 1873d9be-9329-4f53-b9f7-66adfdaee38c
        p57: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c
        p58: TenantConfiguration.*
        p59: {"Actions":["TenantConfiguration.*"]}
        p60: 8d820e06-9e59-4fbd-ac5e-33b57af6ceb3
        p61: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p62: 20de13a8-4db9-4a77-9557-fc1353ee0488
        p63: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p64: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p65: TenantConfiguration.*
        p66: {"Actions":["TenantConfiguration.*"]}
        p67: bad4603e-218a-4acc-964f-6e8310f9e638
        p68: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p69: 8780dd4e-9416-45c1-b118-8bc73971333a
        p70: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p71: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p72: TenantConfiguration.*
        p73: {"Actions":["TenantConfiguration.*"]}
        p74: c392fa85-ae85-4eb6-958b-9829a7008696
        p75: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p76: 82624226-d4d8-4f28-95c9-b6fd43cd6437
        p77: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p78: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p79: TenantConfiguration.*
        p80: {"Actions":["TenantConfiguration.*"]}
        p81: 4fc8f852-3cf2-4a10-a1f2-7516f3b6cbe1
        p82: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p83: 05bb9654-487f-4440-94c5-832da07ddd87
        p84: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p85: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p86: TenantConfiguration.*
        p87: {"Actions":["TenantConfiguration.*"]}
        p88: 65ff4cfb-b991-4a17-b077-7d2a8e67e7e0
        p89: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p90: ddffc31b-3bde-4a3a-8d4b-7aaac9ee68ed
        p91: a0b684d5-cea8-408d-99a9-48d6cee22df5
        p92: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5
        p93: TenantConfiguration.*
        p94: {"Actions":["TenantConfiguration.*"]}
        p95: 1c4eba8c-08f1-4912-ad61-c090300808f3
        p96: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p97: 20de13a8-4db9-4a77-9557-fc1353ee0488
        p98: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p99: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p100: TenantConfiguration.*
        p101: {"Actions":["TenantConfiguration.*"]}
        p102: 409d5f7d-0481-42b9-97ba-69a3ed0ccc16
        p103: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p104: 8780dd4e-9416-45c1-b118-8bc73971333a
        p105: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p106: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p107: TenantConfiguration.*
        p108: {"Actions":["TenantConfiguration.*"]}
        p109: da3c5aa8-df48-4536-859c-8bc2a12c0d5d
        p110: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p111: 82624226-d4d8-4f28-95c9-b6fd43cd6437
        p112: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p113: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p114: TenantConfiguration.*
        p115: {"Actions":["TenantConfiguration.*"]}
        p116: ad319845-05d8-4a7a-b940-8a080e00b5d1
        p117: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p118: 05bb9654-487f-4440-94c5-832da07ddd87
        p119: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p120: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p121: TenantConfiguration.*
        p122: {"Actions":["TenantConfiguration.*"]}
        p123: d5aac8f7-984f-4b73-817b-c61d8b4b5cf3
        p124: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p125: ddffc31b-3bde-4a3a-8d4b-7aaac9ee68ed
        p126: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p127: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p128: TenantConfiguration.*
        p129: {"Actions":["TenantConfiguration.*"]}
        p130: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p131: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p132: ba9dea83-87d7-4ec5-bcc3-70436f1a14d1
        p133: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p134: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p135: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p136: 20de13a8-4db9-4a77-9557-fc1353ee0488
        p137: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p138: 8780dd4e-9416-45c1-b118-8bc73971333a
        p139: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p140: 82624226-d4d8-4f28-95c9-b6fd43cd6437
        p141: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p142: 05bb9654-487f-4440-94c5-832da07ddd87
        p143: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p144: ddffc31b-3bde-4a3a-8d4b-7aaac9ee68ed
        p145: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p146: 31b06cdc-eef4-4014-b97f-42a664e534b2
        p147: True
        p148: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p149: 7bd84bf6-491d-4906-a176-0ef4e9990328
        p150: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p151: 8780dd4e-9416-45c1-b118-8bc73971333a
        p152: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p153: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p154: TenantConfiguration.*
        p155: {"Actions":["TenantConfiguration.*"]}
        p156: 1dede20f-c001-43d8-8380-ad897dbf3794
        p157: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p158: 20de13a8-4db9-4a77-9557-fc1353ee0488
        p159: 7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p160: 31b06cdc-eef4-4014-b97f-42a664e534b2/a0b684d5-cea8-408d-99a9-48d6cee22df5/1873d9be-9329-4f53-b9f7-66adfdaee38c/7a7eed61-8f98-413d-9b55-2bcb52b8adda
        p161: TenantConfiguration.*
        p162: {"Actions":["TenantConfiguration.*"]}
        p163: 4
        p164: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p165: 3
        p166: {"RoleAssignmentId":"cf42839b-20b8-4112-934f-c2aba75d5b9c","OrganizationalUnitId":"31b06cdc-eef4-4014-b97f-42a664e534b2","UserIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":["ddffc31b-3bde-4a3a-8d4b-7aaac9ee68ed","05bb9654-487f-4440-94c5-832da07ddd87","82624226-d4d8-4f28-95c9-b6fd43cd6437","8780dd4e-9416-45c1-b118-8bc73971333a","20de13a8-4db9-4a77-9557-fc1353ee0488"]},"GroupIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":[]},"RoleIds":{"$type":"System.Guid[], System.Private.CoreLib","$values":["ba9dea83-87d7-4ec5-bcc3-70436f1a14d1"]},"AllowInheritance":true}
        p167: role_assignment_updated
        p168: Repro.Api.Domain.RoleAssignmentUpdated, Repro.Api
        p169: 4
        p170: 018dc570-7f51-4a0b-8e60-babebc403ac5
        p171: cf42839b-20b8-4112-934f-c2aba75d5b9c
        p172: 4
        p173: 20/02/2024 07:35:00 +00:00
        p174: *DEFAULT*
dbug: Marten.IDocumentStore[0]
      Marten executed in 1 ms, SQL:
insert into public.mt_streams (id, tenant_id, version)
values (:p0, :p1, 0)
ON CONFLICT (id)
DO NOTHING
;insert into public.mt_events (data, type, mt_dotnet_type, seq_id, id, stream_id, version, timestamp, tenant_id) values (:p2, :p3, :p4, :p5, :p6, :p7, :p8, :p9, :p10);
  p0: 3d52d3b3-b64e-4742-a035-50a36b0a9382
        p1: *DEFAULT*
        p2: {}
        p3: tombstone
        p4: Marten.Events.Operations.Tombstone, Marten
        p5: 4
        p6: 018dc570-8070-45ee-8da6-914d5ab45b82
        p7: 3d52d3b3-b64e-4742-a035-50a36b0a9382
        p8: 4
        p9: 01/01/0001 00:00:00 +00:00
        p10: *DEFAULT*
fail: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware[1]
      An unhandled exception has occurred while executing the request.
      Marten.Exceptions.MartenCommandException: Marten Command Failure:$
      $
      $
      23505: duplicate key value violates unique constraint "pkey_mt_tbl_role_assignment_role_role_assignment_id_role_id"

      DETAIL: Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
       ---> Npgsql.PostgresException (0x80004005): 23505: duplicate key value violates unique constraint "pkey_mt_tbl_role_assignment_role_role_assignment_id_role_id"

      DETAIL: Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
         at Npgsql.Internal.NpgsqlConnector.<ReadMessage>g__ReadMessageLong|234_0(NpgsqlConnector connector, Boolean async, DataRowLoadingMode dataRowLoadingMode, Boolean readingNotifications, Boolean isReadingPrependedMessage)
         at Npgsql.NpgsqlDataReader.NextResult(Boolean async, Boolean isConsuming, CancellationToken cancellationToken)
         at Npgsql.NpgsqlDataReader.NextResult(Boolean async, Boolean isConsuming, CancellationToken cancellationToken)
         at Marten.Internal.UpdateBatch.ApplyCallbacksAsync(IReadOnlyList`1 operations, DbDataReader reader, IList`1 exceptions, CancellationToken token)
         at Marten.Internal.UpdateBatch.ApplyChangesAsync(IMartenSession session, CancellationToken token)
         at Marten.Internal.UpdateBatch.ApplyChangesAsync(IMartenSession session, CancellationToken token)
        Exception data:
          Severity: ERROR
          SqlState: 23505
          MessageText: duplicate key value violates unique constraint "pkey_mt_tbl_role_assignment_role_role_assignment_id_role_id"
          Detail: Detail redacted as it may contain sensitive data. Specify 'Include Error Detail' in the connection string to include this information.
          SchemaName: public
          TableName: mt_tbl_role_assignment_role
          ConstraintName: pkey_mt_tbl_role_assignment_role_role_assignment_id_role_id
          File: nbtinsert.c
          Line: 666
          Routine: _bt_check_unique
         --- End of inner exception stack trace ---
         at JasperFx.Core.Exceptions.ExceptionTransformExtensions.TransformAndThrow(IEnumerable`1 transforms, Exception ex)
         at Marten.Internal.UpdateBatch.ApplyChangesAsync(IMartenSession session, CancellationToken token)
         at Marten.Internal.Sessions.DocumentSessionBase.ExecuteBatchAsync(IUpdateBatch batch, CancellationToken token)
         at Marten.Internal.Sessions.DocumentSessionBase.ExecuteBatchAsync(IUpdateBatch batch, CancellationToken token)
         at Marten.Internal.Sessions.DocumentSessionBase.SaveChangesAsync(CancellationToken token)
         at Internal.Generated.WolverineHandlers.POST_update_assignment_id.Handle(HttpContext httpContext)
         at Internal.Generated.WolverineHandlers.POST_update_assignment_id.Handle(HttpContext httpContext)
         at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
         at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
         at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)
```
