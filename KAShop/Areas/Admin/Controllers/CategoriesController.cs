using KAShop.Data;
using KAShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace KAShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
       
        public ApplicationDBContext context = new ApplicationDBContext();
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Dellete(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if(category is not null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Category category)
        {
            if(ModelState.IsValid)
            {
                var check = context.Categories.FirstOrDefault(c=>c.Name==category.Name);
                if (check is null)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "there is category that has the same name");
                    return View("create",category);
                }
            }
            return View();
        }
    }
}
