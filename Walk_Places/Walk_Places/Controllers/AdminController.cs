using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Walk_Places.Data;

namespace Walk_Places.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private readonly WalkPlacesDbContext _context;

        public AdminController(WalkPlacesDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var admins = _context.Admins.ToList();
            return View(admins);
        }
    }
}
