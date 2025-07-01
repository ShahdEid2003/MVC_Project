using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using MVCProject.Models;
using MVCProject.Services;

namespace MVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.categories = context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product request, IFormFile Image)
        { 
            if(!ModelState.IsValid){
                ViewBag.categories = context.Categories.ToList();
                return  View(request);
            }
            var imageService = new ImageServices();
           string fileName= imageService.UploadFile(Image);
            request.Image = fileName; 
            context.Products.Add(request);
            context.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = context.Products.FirstOrDefault( p=> p.Id == id);
            var imageService = new ImageServices();
            imageService.DeleteImage(product.Image);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            ViewBag.categories = context.Categories.ToList();
            return View(product);

           
        }
        [HttpPost]
        public IActionResult Edit(Product request , IFormFile? Image)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(request);
            }
            var exitingProduct= context.Products.AsNoTracking().FirstOrDefault(p=>p.Id== request.Id);
            if (Image is not null) {
                var imageService = new ImageServices();
                var fileName=imageService.UploadFile(Image);
                request.Image = fileName;
                imageService.DeleteImage(exitingProduct.Image);


            }
            else
            {
                request.Image = exitingProduct.Image;

            }
            context.Products.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}
