using MauiFrontendApplication.Models;

namespace MauiFrontendApplication.DataServices
{
    public interface ILocationsDataService
    {
        Task<List<LocationModel>> GetLocationsAsync();
        Task CreateLocationAsync(LocationModel location);
        Task UpsertLocationAsync(LocationModel location);
        Task DeleteLocationAsync(Guid id);
    }
}

