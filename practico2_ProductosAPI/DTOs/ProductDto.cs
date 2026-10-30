namespace practico2_ProductosAPI.DTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Category { get; set; } = "";
        public bool IsActive { get; set; } = true;
    }
    public class ProductDto : ProductCreateDto 
    {
        public int Id { get; set; }
    }
}
