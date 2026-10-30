using practico2_ProductosAPI.Models;
using practico2_ProductosAPI.Repositories;
using practico2_ProductosAPI.DTOs;

namespace practico2_ProductosAPI.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public List<ProductDto> GetAll()
        {
            return _repo.GetAll().Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category
            }).ToList();
        }

        public ProductDto? GetById(int id)
        {
            var p = _repo.GetById(id);
            if (p == null) return null;
            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category
            };
        }
        public ProductDto Add(ProductCreateDto Dto)
        {
            var product = new Product
            {
                Name = Dto.Name,
                Price = Dto.Price,
                Category = Dto.Category
            };
             _repo.Add(product);

            return new ProductDto { Id = product.Id, Name = product.Name, Price = product.Price, Category = product.Category };
        }
    }
}

