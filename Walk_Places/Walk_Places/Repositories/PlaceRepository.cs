using Microsoft.EntityFrameworkCore;
using Walk_Places.Data;
using Walk_Places.Models;

namespace Walk_Places.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly WalkPlacesDbContext _dbContext;

        public PlaceRepository(WalkPlacesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Place> GetAllPlaces()
        {
            return _dbContext.Places.ToList();
        }

        public Place GetPlaceById(int id)
        {
            return _dbContext.Places.Find(id);
        }

        public void AddPlace(Place place)
        {
            _dbContext.Places.Add(place);
            _dbContext.SaveChanges();
        }

        public void UpdatePlace(Place place)
        {
            _dbContext.Entry(place).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeletePlace(int id)
        {
            var place = _dbContext.Places.Find(id);
            if (place != null)
            {
                _dbContext.Places.Remove(place);
                _dbContext.SaveChanges();
            }
        }
    }
}
