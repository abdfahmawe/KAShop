using Microsoft.AspNetCore.Mvc;

namespace KAShop.Areas.Admin.Controllers
{
    public class CompaniesController : Controller
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
