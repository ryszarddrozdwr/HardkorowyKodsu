using BackendClient.Model;
using Refit;

namespace HardkorowyKodsuClient.Services
{
    public interface IBackendApi
    {
        [Get("/api/database/databasename")]
        Task<string> DatabaseName();
        [Get("/api/database/tables")]
        Task<Table[]> Tables();
        [Get("/api/database/views")]
        Task<Table[]> Views();
        [Get("/api/database/tables/{id}")]
        Task<FullTable> Table(int id);
        [Get("/api/database/views/{id}")]
        Task<FullTable> View(int id);
    }
}
