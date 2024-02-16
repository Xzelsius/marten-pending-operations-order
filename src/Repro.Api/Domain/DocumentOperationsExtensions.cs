namespace Repro.Api.Domain;

using Marten;
using SqlKata;
using SqlKata.Compilers;
using System.Text;
using Weasel.Core;

internal static class DocumentOperationsExtensions
{
    private static readonly PostgresCompiler Compiler = new();

    public static void QueueStatement(this IDocumentOperations ops, DbObjectName tableIdentifier,
        Action<Query> configureStatement)
        => ops.QueueStatement(tableIdentifier.ToString(), configureStatement);

    public static void QueueStatement(this IDocumentOperations ops, string tableIdentifier,
        Action<Query> configureStatement)
    {
        var query = new Query(tableIdentifier);
        configureStatement(query);

        var compiled = Compiler.Compile(query);

        ops.QueueSqlCommand(compiled.RawSql, compiled.Bindings.ToArray());
    }

    public static void QueueCombinedStatements(this IDocumentOperations ops, string tableIdentifier, params Action<Query>[] configureStatements)
    {
        StringBuilder rawSql = new StringBuilder();
        List<object> parameters = new List<object>();

        foreach (var configureStatement in configureStatements)
        {
            var query = new Query(tableIdentifier);
            configureStatement(query);

            var compiled = Compiler.Compile(query);

            rawSql.Append(compiled.RawSql);
            rawSql.Append(';');

            parameters.AddRange(compiled.Bindings);
        }

        ops.QueueSqlCommand(rawSql.ToString(), parameters.ToArray());
    }
}
