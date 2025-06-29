using KAShop.Data;
using KAShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KAShop.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductsController : Controller
    {
        public ApplicationDBContext context = new ApplicationDBContext();
        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product requist , IFormFile Image)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(requist);
            }
            ImageServices imageServices = new ImageServices();
           var fileName = imageServices.UploadImage(Image);
            requist.Image = fileName;
            context.Products.Add(requist);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Dellete(int id)
        {
            var product = context.Products.FirstOrDefault(c => c.Id == id);
            context.Products.Remove(product);
            ImageServices imageServices = new ImageServices();
            imageServices.dellete(product.Image);
           
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            ViewBag.categories = context.Categories.ToList();
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product requist,IFormFile? Image)
        {

            var existingProduct = context.Products.AsNoTracking().First(p => p.Id == requist.Id);
            if(Image is not null)
            {
                ImageServices imageServices = new ImageServices();
               var newimgname =  imageServices.UploadImage(Image);
                requist.Image = newimgname;
                imageServices.dellete(existingProduct.Image);
            }
            else
            {
                requist.Image = existingProduct.Image;
            }
            context.Products.Update(requist);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
