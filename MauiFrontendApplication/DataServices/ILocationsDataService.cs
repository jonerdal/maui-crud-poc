using MauiFrontendApplication.Models;

namespace MauiFrontendApplication.DataServices
{
    public interface ILocationsDataService
    {
        Task<List<LocationModel>> GetLocationsAsync();
        Task<LocationModel> GetLocationAsync(Guid id);
        Task CreateLocationAsync(LocationModel location);
        Task UpsertLocationAsync(LocationModel location);
        Task DeleteLocationAsync(Guid id);
    }
}

