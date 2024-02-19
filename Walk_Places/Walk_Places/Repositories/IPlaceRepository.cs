using Walk_Places.Models;

namespace Walk_Places.Repositories
{
    public interface IPlaceRepository
    {
        IEnumerable<Place> GetAllPlaces();
        Place GetPlaceById(int id);
        void AddPlace(Place place);
        void UpdatePlace(Place place);
        void DeletePlace(int id);
    }
}
