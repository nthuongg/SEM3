using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{
    [ApiController]
    [Route("/api/category")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly T2210mApiContext _context;
        public CategoryController(T2210mApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CategoryDTO> ls = _context.Categories
                .Select(m=> new CategoryDTO
                {
                    id = m.Id,
                    name = m.Name
                })
                .ToList();
            return Ok(ls);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Category category = new Category { Name = model.name};
                    _context.Categories.Add( category );
                    _context.SaveChanges();
                    return Created("", new CategoryDTO { id = category.Id, name = category.Name});
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);   
                }
            }
            return BadRequest("Error");
        }

        [HttpPut]
        public IActionResult Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Categories.Update(new Category { Id = model.id, Name = model.name });
                    _context.SaveChanges();
                    return Ok("Successfully");
                }
                catch(Exception e) 
                {
                    return BadRequest(e.Message);                
                }
            }
            return BadRequest("Error");
        }

        [HttpDelete]
        //Xóa thì phải là super admin (root@admin.com)
        [Authorize(Policy = "SuperAdmin")]
        public IActionResult Delete(int id)
        {
            try
            {
                Category category = _context.Categories.Find(id);
                _context.Categories.Remove(category);   
                _context.SaveChanges(); 
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
