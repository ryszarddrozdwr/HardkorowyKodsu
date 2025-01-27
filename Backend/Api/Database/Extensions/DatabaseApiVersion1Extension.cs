//using Backend.Api.Database.Dto;
using BackendClient.Model;
using Dapper;
using C = Microsoft.Data.SqlClient;

namespace Backend.Api.Extensions
{
    public static class DatabaseApiVersion1Extension
    {
        const string ViewsQuery = """
            select
                v.object_id as id
                , s.name as sname
                , v.name as oname
            from
                sys.schemas s 
                inner join sys.views v on s.schema_id = v.schema_id
            order by
                s.name, v.name
            """;
        const string TablesQuery = """
            select
                t.object_id as id
                , s.name as sname
                , t.name as oname
            from
                sys.schemas s 
                inner join sys.tables t on s.schema_id = t.schema_id
            order by
                s.name, t.name
            """;
        const string SingleViewQuery = """
            select
                v.object_id as id
                , s.name as sname
                , v.name as oname
            from
                sys.schemas s 
                inner join sys.views v on s.schema_id = v.schema_id
            where v.object_id = @id
            """;
        const string SingleTableQuery = """
            select
                t.object_id as id
                , s.name as sname
                , t.name as oname
            from
                sys.schemas s 
                inner join sys.tables t on s.schema_id = t.schema_id
            where t.object_id = @id
            """;
        const string ObjectColumnsQuery = """
            select [name] as cname from sys.columns where object_id = @id
            """;
        public static void AddDatabaseApiVersion1(this RouteGroupBuilder parentGroup, string connectionString, string databaseName)
        {
            var group = parentGroup.MapGroup("database");

            group.MapGet("databasename", () => databaseName);

            group.MapGet("tables", () => {
                using var connection = new C.SqlConnection(connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"use {databaseName}";
                command.ExecuteNonQuery();
                return connection.Query<Table>(TablesQuery).ToArray();
            });

            group.MapGet("tables/{id}", (int id) => {
                using var connection = new C.SqlConnection(connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"use {databaseName}";
                command.ExecuteNonQuery();
                var parameters = new { id = id };
                var table = connection.Query<Table>(SingleTableQuery, parameters).FirstOrDefault();
                if (table == null)
                    return Results.NotFound(id);
                var columns = connection.Query<Column>(ObjectColumnsQuery, parameters).ToArray();
                return Results.Ok(new FullTable { id = id, sname = table?.sname ?? "", oname = table?.oname ?? "", otype = "t", columns = columns });
            });

            group.MapGet("views", () => {
                using var connection = new C.SqlConnection(connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"use {databaseName}";
                command.ExecuteNonQuery();
                return connection.Query<Table>(ViewsQuery).ToArray();
            });

            group.MapGet("views/{id}", (int id) => {
                using var connection = new C.SqlConnection(connectionString);
                connection.Open();
                using var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"use {databaseName}";
                command.ExecuteNonQuery();
                var parameters = new { id = id };
                var table = connection.Query<Table>(SingleViewQuery, parameters).FirstOrDefault();
                if (table == null)
                    return Results.NotFound(id);
                var columns = connection.Query<Column>(ObjectColumnsQuery, parameters).ToArray();
                return Results.Ok(new FullTable { id = id, sname = table?.sname ?? "", oname = table?.oname ?? "", otype = "v", columns = columns });
            });
        }
    }
}
