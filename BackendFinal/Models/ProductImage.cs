namespace BackendFinal.Models
{
    public class ProductImage : BaseEntity
    {
        public string ImgUrl { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public ProductImage()
        {
            IsMain = false;
            IsDeleted = false;
        }
    }
}
