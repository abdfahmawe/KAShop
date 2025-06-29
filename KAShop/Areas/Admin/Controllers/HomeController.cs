using KAShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace KAShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public ApplicationDBContext context = new ApplicationDBContext();

        public IActionResult Index()
        {
          
            return View();
        }
    }
}
