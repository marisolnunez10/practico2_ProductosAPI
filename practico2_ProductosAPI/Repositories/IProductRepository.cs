using practico2_ProductosAPI.Models;

namespace practico2_ProductosAPI.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        List<Product> GetAll();
        Product? GetById(int id);
        List<Product> FilterByCategory(string category);
    }
}
