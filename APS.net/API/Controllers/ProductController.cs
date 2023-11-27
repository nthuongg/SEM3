using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/product")]
    public class ProductController : Controller
    {
        private readonly T2210mApiContext _context;
        public ProductController(T2210mApiContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Index()
        {
            List<ProductDTO> ls = _context.Products
                .Select(m => new ProductDTO
                {
                    id = m.Id,
                    name = m.Name,
                    thumbnail = m.Thumbnail,
                    price = m.Price,
                    qty = m.Qty,
                    description = m.Description
                })
                .ToList();
            return Ok(ls);
        }
    }
}
