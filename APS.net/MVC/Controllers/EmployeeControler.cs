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
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employee> ls = _context.Employees.ToList();
            return View(ls);
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                
                //save to db
                _context.Employees.Add(new Employee { Name = model.Name});
                _context.SaveChanges();

                //redirect to list
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();
            return View(new EmployeeModel { Id = employee.Id, Name = employee.Name });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(new Employee { Id = model.Id, Name = model.Name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public IActionResult Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}