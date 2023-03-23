using Locations.Models;

namespace Locations.Services
{
    public interface ILocationsService
    {
        void CreateLocation(Location location);
        Location? GetLocation(Guid id);
        List<Location> GetAllLocations();
        void UpsertLocation(Location location);
        void DeleteLocation(Guid id);


    }
}
