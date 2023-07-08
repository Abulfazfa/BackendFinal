namespace BackendFinal.ViewModels
{
    public class BlogVM
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ImgUrl { get; set; }
        public string Date { get; set; }
        public string CreatedDate { get; set; }
    }
}
