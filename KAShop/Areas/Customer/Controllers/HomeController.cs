using KAShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace KAShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public ApplicationDBContext context = new ApplicationDBContext();
        public IActionResult Index()
        {
            ViewBag.categories = context.Categories.ToList();
            ViewBag.products = context.Products.ToList();
            return View();
            
        }
    }
}
