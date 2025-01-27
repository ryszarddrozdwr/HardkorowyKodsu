using Microsoft.Data.SqlClient;

namespace Backend.Api
{
    public class ExceptionHandlingFilter : IEndpointFilter
    {
        private readonly ILogger _logger;
        const int NoPrincipalToAccessDatabase = 916;
        public ExceptionHandlingFilter(ILogger<ExceptionHandlingFilter> logger)
        {
            _logger = logger;
        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            try
            {
                return await next(context);
            }
            catch (SqlException sex)
            {
                if (sex.Number == NoPrincipalToAccessDatabase)
                {
                    _logger.LogError("SQl Server: current user can't access database.");
                    return Results.Problem("SQl Server: current user can't access database.");
                }
                _logger.LogError($"Unexpected sql error ({sex.ErrorCode}, {sex.Number}).");
                return Results.Problem($"Unexpected sql error ({sex.ErrorCode}, {sex.Number}). Try again.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                return Results.Problem("Unexpected error. Try again.");
            }
        }
    }
}
