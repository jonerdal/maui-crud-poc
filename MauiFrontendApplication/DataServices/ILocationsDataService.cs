using MauiFrontendApplication.Models;

namespace MauiFrontendApplication.DataServices
{
    public interface ILocationsDataService
    {
        Task<List<LocationModel>> GetLocationsAsync();
        Task<LocationModel> GetLocationAsync(Guid id);
        Task<LocationModel> CreateLocationAsync(LocationModel location);
        Task<bool> UpsertLocationAsync(LocationModel location);
        Task<bool> DeleteLocationAsync(Guid id);
    }
}

