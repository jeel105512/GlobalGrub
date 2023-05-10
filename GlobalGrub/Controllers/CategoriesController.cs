using Microsoft.AspNetCore.Mvc;

namespace GlobalGrub.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // /categories/browse?category=abc - show selected category
        public IActionResult Browse(string category)
        {
            // store input parameter in a var inside a ciewbag so we can display the user's selection
            ViewBag.category = category;

            return View();
        }
    }
}
