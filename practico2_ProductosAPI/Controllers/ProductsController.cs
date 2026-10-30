using Microsoft.AspNetCore.Mvc;
using practico2_ProductosAPI.DTOs;
using practico2_ProductosAPI.Repositories;
using practico2_ProductosAPI.Models;

namespace practico2_ProductosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo) { _repo = repo; }

        [HttpGet]
        public IActionResult Get() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var p = _repo.GetById(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpGet("category/{category}")]
        public IActionResult FilterByCategory(string category) => Ok(_repo.FilterByCategory(category));

        [HttpPost]
        public IActionResult Post([FromBody] ProductCreateDto Dto)
        {
            var Product = new Product
            {
                Name = Dto.Name,
                Price = Dto.Price,
                Category = Dto.Category,
                IsActive = Dto.IsActive
            };
            _repo.Add(Product);
            return CreatedAtAction(nameof(GetById), new { id = Product.Id }, Product);
        }
    }
}
