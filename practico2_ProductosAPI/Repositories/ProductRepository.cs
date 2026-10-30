using practico2_ProductosAPI.Models;

namespace practico2_ProductosAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
            _products.Add(new Product { Id = 1, Name = "HP Laptop", Price = 10.99m, Category = "Technology", IsActive = true });
            _products.Add(new Product { Id = 2, Name ="iPad", Price = 30.99m, Category = "Technology", IsActive = true});
            _products.Add(new Product { Id = 3, Name ="Mario Bros World", Price = 50.99m, Category = "Gamer", IsActive = true });
            _products.Add(new Product { Id = 4, Name ="Hollow Knight", Price = 69.99m, Category = "Gamer", IsActive = true });
         }

        public void Add(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
        }
         public List<Product> GetAll() => _products.ToList();
         public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public List<Product> FilterByCategory(string category) => _products.Where(p => p.Category.ToLower() == category.ToLower()).ToList();
    }
}

