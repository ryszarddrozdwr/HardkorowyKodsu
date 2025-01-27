using Backend.Api;
using Backend.Api.Database;
using Backend.Api.Extensions;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

        // Add services to the container.

        const string SqlConnectionName = "DatabaseConnection";
        const string DatabaseName = "Database";

        var connectionString = builder.Configuration.GetConnectionString(SqlConnectionName);
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception($"Configuration Error. Check configuration: ConnectionString");
        }
        var databaseName = builder.Configuration.GetValue<string>(DatabaseName);
        if (string.IsNullOrEmpty(databaseName))
        {
            throw new Exception($"Configuration Error. Check configuration: Database");
        }
        if(!(new DatabaseNameValidator().Check(connectionString,databaseName)))
        {
            throw new Exception($"Configuration Error. Check DatabaseName: {databaseName}");
        }

        var app = builder.Build();
        app.UseSerilogRequestLogging();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();
        var api = app.MapGroup("api");
        api.AddEndpointFilter<ExceptionHandlingFilter>();

        api.AddDatabaseApi(connectionString, databaseName);
        var v1 = api.MapGroup("v1");
        v1.AddDatabaseApiVersion1(connectionString, databaseName);

        app.Run();
    }
}