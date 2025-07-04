﻿using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Data;
using MVCProject.Models;

namespace MVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category request)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(request);
                context.SaveChanges();  
                return RedirectToAction("index");

            }
            return View();
        }
        public IActionResult Delete(int id)
        {
          
            var category = context.Categories.FirstOrDefault(c=>c.Id==id);
            if(category is not null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();  
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category request)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = context.Categories.FirstOrDefault(c => c.Id == request.Id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                existingCategory.Name = request.Name;
               
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request); 
        }


    }
}
