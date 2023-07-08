using BackendFinal.Models;

namespace BackendFinal.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Banner> Banners { get; set; }
        public Bio Bios { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Say> Says { get; set; }
    }
}
