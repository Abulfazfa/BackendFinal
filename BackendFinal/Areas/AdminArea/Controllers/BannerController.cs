using BackendFinal.DAL;
using BackendFinal.Helper;
using BackendFinal.Models;
using BackendFinal.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackendFinal.Areas.AdminArea.Controllers
{
    public class BannerController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BannerController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Banners.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(BannerVM bannerVM)
        {

            if (!bannerVM.Photo.CheckFileType())
            {
                ModelState.AddModelError("Photo", "Sellect a image");
                return View();

            }

            Banner banner = new()
            {
                ImgUrl = bannerVM.Photo.SaveImage(_webHostEnvironment, "images"),
            };
            _appDbContext.Banners.Add(banner);
            _appDbContext.SaveChanges();


            return RedirectToAction("Index");



        }
    }
}
