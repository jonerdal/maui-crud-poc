using MauiFrontendApplication.Models;

namespace MauiFrontendApplication.DataServices
{
    public interface ILocationsDataService
    {
        Task<List<LocationModel>> GetLocationsAsync();
        Task<LocationModel> GetLocationAsync(Guid id);
        Task<LocationModel> CreateLocationAsync(LocationModel location);
        Task UpsertLocationAsync(LocationModel location);
        Task DeleteLocationAsync(Guid id);
    }
}

