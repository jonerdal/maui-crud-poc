using Locations.Models;
using Locations.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Locations.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly LocationDbContext _dbContext;

        public LocationsService(LocationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateLocation(Location location)
        {
            _dbContext.Add(location);
            _dbContext.SaveChanges();
        }

        public void DeleteLocation(Guid id)
        {
            var location = _dbContext.Locations.Find(id);

            if (location != null)
            {
                _dbContext.Remove(location);
                _dbContext.SaveChanges();
            }

            //TODO return 404 if we did not find location to delete
        }

        public List<Location> GetAllLocations()
        {

            return _dbContext.Locations.ToList();
        }

        public Location? GetLocation(Guid id)
        {
            var location = _dbContext.Locations.Find(id);

            if (location != null)
            {
                return location;
            }

            //TODO return 404 if we did not find location
            return null;
        }

        public void UpsertLocation(Location location)
        {
            var exists = _dbContext.Locations.Any(l => l.Id == location.Id);

            if (exists)
            {
                //204 if we update it
                _dbContext.Update(location);
            }
            else
            {
                //201 if we create it
                _dbContext.Add(location);
            }

            _dbContext.SaveChanges();
        }
    }
}
