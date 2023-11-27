using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Entities;
using MVC.Models;
using MVC.Entities;
using MVC.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Category> ls = _context.Categories.ToList();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }

      

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                string imageName = null;
                //upload to wwwroot/upload
                if(model.Image != null)
                {
                    var image = model.Image;
                    string path = "wwwroot/uploads";
                    string fileName = Guid.NewGuid().ToString() 
                        + Path.GetExtension(image.FileName);
                    var upload = Path.Combine(Directory.GetCurrentDirectory(),path, fileName);
                    image.CopyTo(new FileStream(upload, FileMode.Create));
                    imageName = "~/uploads/" + fileName;
                }
                //save to db
                _context.Categories.Add(new Category { Name = model.Name, Image = imageName });
                _context.SaveChanges();

                //redirect to list
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null) 
                return NotFound();  
            return View(new CategoryModel { Id = category.Id, Name = category.Name});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {              
                _context.Categories.Update(new Category { Id = model.Id, Name = model.Name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if(category == null)
                return NotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}