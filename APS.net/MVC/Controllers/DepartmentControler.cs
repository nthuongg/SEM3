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
    public class DepartmentControler : Controller
    {
        private readonly DataContext _context;

        public DepartmentControler(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Department> ls = _context.Departments.ToList();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                
                //save to db
                _context.Departments.Add(new Department { Name = model.Name});
                _context.SaveChanges();

                //redirect to list
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department department = _context.Departments.Find(id);
            if (department == null)
                return NotFound();
            return View(new DepartmentModel { Id = department.Id, Name = department.Name });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(new Department { Id = model.Id, Name = model.Name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public IActionResult Delete(int id)
        {
            Department department = _context.Departments.Find(id);
            if (department == null)
                return NotFound();
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}