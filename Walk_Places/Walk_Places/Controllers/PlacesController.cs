using Microsoft.AspNetCore.Mvc;
using Walk_Places.Data;

namespace Walk_Places.Controllers
{
    public class PlacesController : Controller
    {
        private readonly WalkPlacesDbContext _context;

        public PlacesController(WalkPlacesDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var places = _context.Places.ToList();
            return View(places);
        }
    }
}
