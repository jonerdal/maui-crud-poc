using Locations.Models;

namespace Locations.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly Dictionary<Guid, Location> _dictionary = new();

        public void CreateLocation(Location location)
        {
            _dictionary.Add(location.Id, location);
        }

        public void DeleteLocation(Guid Id)
        {
            _dictionary.Remove(Id);
        }

        public List<Location> GetAllLocations()
        {
            return _dictionary.Select(x => x.Value).ToList();
        }

        public Location? GetLocation(Guid Id)
        {
            _dictionary.TryGetValue(Id, out var location);
            return location;
        }

        public void UpsertLocation(Location location)
        {
            _dictionary[location.Id] = location;
        }
    }
}
