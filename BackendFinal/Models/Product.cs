namespace BackendFinal.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double OldPrice { get; set; }
        public double Price { get; set; }
        public string? Desc { get; set; }
        public string? Brand { get; set; }
        public int ProductCount { get; set; }
        public List<ProductImage> Images { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Product()
        {
            Images = new List<ProductImage>();
            IsDeleted = false;
        }
    }
}
