namespace BackendFinal.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductCount { get; set; }
        public List<ProductImage> Images { get; set; }
        public Product()
        {
            Images = new List<ProductImage>();
        }
    }
}
