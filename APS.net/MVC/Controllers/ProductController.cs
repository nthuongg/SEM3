using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Entities;
using MVC.Models;
using MVC.Entities;
using MVC.Models;
namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Product> ls = _context.Products.ToList();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                string imageName = null;
                //upload to wwwroot/upload
                if (model.Image != null)
                {
                    var image = model.Image;
                    string path = "wwwroot/uploads";
                    string fileName = Guid.NewGuid().ToString()
                        + Path.GetExtension(image.FileName);
                    var upload = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
                    image.CopyTo(new FileStream(upload, FileMode.Create));
                    imageName = "~/uploads/" + fileName;
                }
                //save to db
                _context.Products.Add(new Product { Name = model.Name, Price = model.Price, Description = model.Description, Quantity = model.Quantity, Image = imageName });
                _context.SaveChanges();

                //redirect to list
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
