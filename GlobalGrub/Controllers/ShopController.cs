using GlobalGrub.Data;
using Microsoft.AspNetCore.Mvc;

namespace GlobalGrub.Controllers
{
    public class ShopController : Controller
    {
        // add DbContext to use the database
        private readonly ApplicationDbContext _context;

        // constructor
        public ShopController(ApplicationDbContext context)
        {
            _context = context; // assign incoming db connection so we can use it in any method in this controller
        }

        public IActionResult Index()
        {
            // use Categories DbSet to fetch the list of Categories to display to shoppers
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            return View(categories);
        }
    }
}
