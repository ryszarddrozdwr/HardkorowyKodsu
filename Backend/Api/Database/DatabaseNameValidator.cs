using C = Microsoft.Data.SqlClient;
using Dapper;

namespace Backend.Api.Database
{
    public class DatabaseNameValidator
    {
        const string DatabasesQuery = "select [name] from sys.databases";
        public bool Check(string connectionString, string name)
        {
            using var connection = new C.SqlConnection(connectionString);
            connection.Open();
            var names = connection.Query<string>(DatabasesQuery).ToArray();
            return names.Any(x => x == name);
        }
    }
}
