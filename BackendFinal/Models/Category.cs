namespace BackendFinal.Models
{
    public class Category : BaseEntity
    {
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
