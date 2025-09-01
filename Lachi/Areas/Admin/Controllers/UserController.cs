using Microsoft.AspNetCore.Mvc;

namespace Lachi.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
