# Pending Changes Order Issue

## Setup

This repro requires a working PostgreSQL server and database.
Simply run this command to create a new PostgreSQL server in Docker

```
docker run --name wolverine-repro -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres
```

## Reproduction Steps

1. Start PostgreSQL container using command from Setup section
2. Start application (either by debugging or dotnet run)
3. Create Role Assignment with 1 user and inheritance `true`
4. Update Role Assignment with 5 users and inheritance `true`

Step 4 will fail because the order of the queued statements has changed.
But it is crucial that the delete statement runs first before trying to insert data.

## Teardown

Remove the created PostgreSQL server with this command

```
docker rm -f -v wolverine-repro
```
