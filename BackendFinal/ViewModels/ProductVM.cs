using BackendFinal.Models;

namespace BackendFinal.ViewModels
{
    public class ProductVM
    {
        public string Name { get; set; }
        public double OldPrice { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public string Brand { get; set; }
        public int ProductCount { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<IFormFile> Photos { get; set; }


    }
}
