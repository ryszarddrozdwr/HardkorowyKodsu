//using Backend.Api.Database.Dto;
using BackendClient.Model;
using Dapper;
using C = Microsoft.Data.SqlClient;

namespace Backend.Api.Extensions
{
    public static class DatabaseApiExtension
    {
        const string ViewsQuery = """
            select
                v.object_id as id
                , s.name as sname
                , v.name as oname
            from
                {DB}.sys.schemas s 
                inner join {DB}.sys.views v on s.schema_id = v.schema_id
            order by
                s.name, v.name
            """;
        const string TablesQuery = """
            select
                t.object_id as id
                , s.name as sname
                , t.name as oname
            from
                {DB}.sys.schemas s 
                inner join {DB}.sys.tables t on s.schema_id = t.schema_id
            order by
                s.name, t.name
            """;
        const string SingleViewQuery = """
            select
                v.object_id as id
                , s.name as sname
                , v.name as oname
            from
                {DB}.sys.schemas s 
                inner join {DB}.sys.views v on s.schema_id = v.schema_id
            where v.object_id = @id
            """;
        const string SingleTableQuery = """
            select
                t.object_id as id
                , s.name as sname
                , t.name as oname
            from
                {DB}.sys.schemas s 
                inner join {DB}.sys.tables t on s.schema_id = t.schema_id
            where t.object_id = @id
            """;
        const string ObjectColumnsQuery = """
            select [name] as cname from {DB}.sys.columns where object_id = @id
            """;
        public static void AddDatabaseApi(this RouteGroupBuilder parentGroup, string connectionString, string databaseName)
        {
            var group = parentGroup.MapGroup("database");

            group.MapGet("databasename", () => databaseName);

            group.MapGet("tables", () => {
                using var connection = new C.SqlConnection(connectionString);
                connection.Open();
                return connection.Query<Table>(TablesQuery.Replace("{DB}", databaseName)).ToArray();
            });

            group.MapGet("tables/{id}", (int id) => {
                using var connection = new C.SqlConnection(connectionString);
                connection.Open();
                var parameters = new { id = id };
                var table = connection.Query<Table>(SingleTableQuery.Replace("{DB}", databaseName), parameters).FirstOrDefault();
                if (table == null)
                    return Results.NotFound(id);
                var columns = connection.Query<Column>(ObjectColumnsQuery.Replace("{DB}", databaseName), parameters).ToArray();
                return Results.Ok(new FullTable { id = id, sname = table?.sname ?? "", oname = table?.oname ?? "", otype = "t", columns = columns });
            });

            group.MapGet("views", () => {
                using var connection = new C.SqlConnection(connectionString);
                connection.Open();
                return connection.Query<Table>(ViewsQuery.Replace("{DB}", databaseName)).ToArray();
            });

            group.MapGet("views/{id}", (int id) => {
                using var connection = new C.SqlConnection(connectionString);
                connection.Open();
                var parameters = new { id = id };
                var table = connection.Query<Table>(SingleViewQuery.Replace("{DB}", databaseName), parameters).FirstOrDefault();
                if (table == null)
                    return Results.NotFound(id);
                var columns = connection.Query<Column>(ObjectColumnsQuery.Replace("{DB}", databaseName), parameters).ToArray();
                return Results.Ok(new FullTable { id = id, sname = table?.sname ?? "", oname = table?.oname ?? "", otype = "v", columns = columns });
            });
        }
    }
}
